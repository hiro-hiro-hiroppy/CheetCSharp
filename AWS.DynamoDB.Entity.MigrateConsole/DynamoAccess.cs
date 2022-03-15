using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AWS.DynamoDB.Entity.MigrateConsole
{
    internal class DynamoAccess
    {
        /// <summary>
        /// 作成場所のURL(docker-composeと一致させる)
        /// </summary>
        private static string ServiceUrl = "http://localhost:8000";

        public static async Task CreateSimpleTable<T>()
        {
            using var awsClient = new AmazonDynamoDBClient(
                new AmazonDynamoDBConfig
                {
                    ServiceURL = ServiceUrl,
                    UseHttp = true
                });

            var type = typeof(T);
            var tableAttr = type.GetCustomAttribute<DynamoDBTableAttribute>();
            var tableName = tableAttr?.TableName ?? type.Name;
            var tableList = await awsClient.ListTablesAsync();

            // 一致した名称のテーブルがすでにできていれば削除する
            if (tableList.TableNames.Any(tb => tb == tableName))
            {
                Console.WriteLine($"Drop Table {tableName}");
                var dropResult = await awsClient.DeleteTableAsync(tableName);
                Console.WriteLine($"Drop Status {dropResult.HttpStatusCode}");
                if (dropResult.HttpStatusCode != HttpStatusCode.OK) return;
            }

            // テーブルのプロパティを作成
            var properties = type.GetProperties().Select(prop =>
            {
                return
                new
                {
                    Name = prop.GetCustomAttributes<DynamoDBPropertyAttribute>()?.FirstOrDefault(a => !string.IsNullOrEmpty(a.AttributeName))?.AttributeName ?? prop.Name,
                    Prop = prop,
                    Key = prop.GetCustomAttributes<DynamoDBHashKeyAttribute>().FirstOrDefault(a => a.GetType().FullName == typeof(DynamoDBHashKeyAttribute).FullName),
                    Range = prop.GetCustomAttributes<DynamoDBRangeKeyAttribute>().FirstOrDefault(a => a.GetType().FullName == typeof(DynamoDBRangeKeyAttribute).FullName),
                    Attr = prop.GetCustomAttributes<DynamoDBPropertyAttribute>().FirstOrDefault(a => !string.IsNullOrEmpty(a.AttributeName)),
                    Ignore = prop.GetCustomAttributes<DynamoDBIgnoreAttribute>().FirstOrDefault(),

                    GSIKey = prop.GetCustomAttributes<DynamoDBGlobalSecondaryIndexHashKeyAttribute>().FirstOrDefault(),
                    GSIRange = prop.GetCustomAttributes<DynamoDBGlobalSecondaryIndexRangeKeyAttribute>().FirstOrDefault(),
                    LSIRange = prop.GetCustomAttributes<DynamoDBLocalSecondaryIndexRangeKeyAttribute>().FirstOrDefault(),
                };
            }).Where(prop => prop.Ignore == null).ToList();

            var localKeySchema = properties.Where(prop => prop.Key != null || prop.Range != null).Select(prop => new KeySchemaElement
            {
                AttributeName = prop.Name,
                KeyType = prop.Key != null ? KeyType.HASH : KeyType.RANGE
            }).ToList();

            var attrDefine = properties.Where(prop => prop.Key != null || prop.Range != null || prop.GSIKey != null || prop.GSIRange != null || prop.LSIRange != null)
                .Select(prop => new AttributeDefinition
                {
                    AttributeName = prop.Name,
                    AttributeType = GetScalarType(prop.Prop.PropertyType)
                }).ToList();

            // GSIの生成
            var gsiList = new List<GlobalSecondaryIndex>();
            var gsiHashList = properties.Where(prop => prop.GSIKey != null);
            var gsiKeys = gsiHashList.Select(gh => gh.GSIKey.IndexNames.Select(gkey => new { IndexName = gkey, Prop = gh })).SelectMany(x => x);
            foreach (var gsiHashKey in gsiKeys)
            {
                var gsiRangeKey = properties.FirstOrDefault(prop => prop.GSIRange != null && prop.GSIRange.IndexNames.Any(rangeName => rangeName == gsiHashKey.IndexName));
                var schema = new List<KeySchemaElement>
                {
                    new KeySchemaElement
                    {
                        AttributeName = gsiHashKey.Prop.Name,
                        KeyType = KeyType.HASH,
                    }
                };

                if (gsiRangeKey != null)
                {
                    schema.Add(new KeySchemaElement
                    {
                        AttributeName = gsiRangeKey.Name,
                        KeyType = KeyType.RANGE
                    });
                }

                var gsi = new GlobalSecondaryIndex
                {
                    IndexName = gsiHashKey.IndexName,
                    ProvisionedThroughput = new ProvisionedThroughput { ReadCapacityUnits = 10L, WriteCapacityUnits = 10L },
                    KeySchema = schema,
                    Projection = new Projection
                    {
                        ProjectionType = "ALL"
                    }
                };
                gsiList.Add(gsi);
            }

            // LSIの生成
            var lsiList = new List<LocalSecondaryIndex>();
            var lsiRangeList = properties.Where(prop => prop.LSIRange != null);
            var lsiRangeKeys = lsiRangeList.Select(lr => lr.LSIRange.IndexNames.Select(lkey => new { IndexName = lkey, Prop = lr })).SelectMany(x => x);
            foreach (var lsiRangeKey in lsiRangeKeys)
            {
                var schema = new List<KeySchemaElement>
                {
                    localKeySchema.Single(x => x.KeyType == KeyType.HASH),
                    new KeySchemaElement
                    {
                        AttributeName = lsiRangeKey.Prop.Name,
                        KeyType = KeyType.RANGE,
                    }
                };

                var lsi = new LocalSecondaryIndex
                {
                    IndexName = lsiRangeKey.IndexName,
                    KeySchema = schema,
                    Projection = new Projection
                    {
                        ProjectionType = "ALL"
                    }
                };
                lsiList.Add(lsi);
            }

            var request = new CreateTableRequest
            {
                TableName = tableName,
                KeySchema = localKeySchema,
                AttributeDefinitions = attrDefine,
                ProvisionedThroughput = new ProvisionedThroughput { ReadCapacityUnits = 10, WriteCapacityUnits = 10 },
                GlobalSecondaryIndexes = gsiList,
                LocalSecondaryIndexes = lsiList,
            };

            // テーブル作成
            var result = await awsClient.CreateTableAsync(request);
            Console.WriteLine($"Create Table {tableName}");
        }

        private static ScalarAttributeType GetScalarType(Type a)
        {
            var typeSCodes = new HashSet<TypeCode>(new[] { TypeCode.String, TypeCode.Char, TypeCode.DateTime });
            return typeSCodes.Contains(Type.GetTypeCode(a)) || a.Name.Equals("Guid") ? ScalarAttributeType.S : ScalarAttributeType.N;
        }
    }
}
