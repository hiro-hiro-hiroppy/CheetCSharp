using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;

using AWS.ApiGateway.Lambda;
using System.Net;
using AWS.ApiGateway.Lambda.Model;
using Newtonsoft.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using dynamoEntity = AWS.DynamoDB.Entity.Entity;
using dynamoModel = AWS.DynamoDB.Entity.Model;
using Amazon.DynamoDBv2.DocumentModel;

namespace AWS.ApiGateway.Lambda.Tests
{
    public class DynamoDBCrudFunctionTest
    {
        private TestLambdaContext context;
        private APIGatewayProxyRequest request;
        private APIGatewayProxyResponse response;
        private DynamoDBCrudFunction functions;
        private static AmazonDynamoDBClient awsClient;

        public DynamoDBCrudFunctionTest()
        {
            functions = new DynamoDBCrudFunction();
            context = new TestLambdaContext();
            awsClient = new AmazonDynamoDBClient(
                new AmazonDynamoDBConfig
                {
                    ServiceURL = "http://localhost:8000",
                    UseHttp = true
                });
        }

        [Fact]
        public async void DynamoDBCrudFunctionのCreate機能テスト()
        {
            var expected = new Study
            {
                Id = new Random().Next(1, 100000000),
                StudyEndTime = DateTime.Now,
                StudyPlace = "教室",
                Subjects = new List<Subject>
                {
                    new Subject
                    {
                        SubjectName = "国語",
                        StudyMinutes = 60,
                        StudyContent = "漢字のお勉強",
                    }
                },
                CrudType = Enum.EnumCrudType.CrudType.Create,
            };
            string body = JsonConvert.SerializeObject(expected);
            request = new APIGatewayProxyRequest() { Body = body };
            response = await functions.FunctionHandler(request, context);

            //登録データを取得
            var dbContext = new DynamoDBContext(awsClient);
            var queryConfig = new QueryOperationConfig();
            var queryFilter = new QueryFilter();
            queryFilter.AddCondition(nameof(dynamoEntity.Study.Id), QueryOperator.Equal, expected.Id);
            queryFilter.AddCondition(nameof(dynamoEntity.Study.StudyEndTime), QueryOperator.Equal, expected.StudyEndTime);
            queryConfig.Filter = queryFilter;
            queryConfig.Limit = 1;
            var actual = await dbContext.FromQueryAsync<dynamoEntity.Study>(queryConfig).GetNextSetAsync();

            //比較
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
            Assert.Single(actual);
            Assert.Equal(expected.Id, actual.Single().Id);
            Assert.Equal(expected.StudyEndTime.ToString("yyyyMMddHHmmss"), actual.Single().StudyEndTime.ToString("yyyyMMddHHmmss"));
            Assert.Equal(expected.StudyPlace, actual.Single().StudyPlace);

            Assert.Single(actual.Single().Subjects);
            Assert.Equal(expected.Subjects.Single().StudyContent, actual.Single().Subjects.Single().StudyContent);
            Assert.Equal(expected.Subjects.Single().StudyMinutes, actual.Single().Subjects.Single().StudyMinutes);
            Assert.Equal(expected.Subjects.Single().SubjectName, actual.Single().Subjects.Single().SubjectName);
        }

        [Fact]
        public async void DynamoDBCrudFunctionのRead機能テスト()
        {
            // データを登録
            var expected = new Study
            {
                Id = new Random().Next(1, 100000000),
                StudyEndTime = DateTime.Now,
                StudyPlace = "教室",
                Subjects = new List<Subject>
                {
                    new Subject
                    {
                        SubjectName = "国語",
                        StudyMinutes = 60,
                        StudyContent = "漢字のお勉強",
                    }
                },
                CrudType = Enum.EnumCrudType.CrudType.Create,
            };
            string createBody = JsonConvert.SerializeObject(expected);
            var createRequest = new APIGatewayProxyRequest() { Body = createBody };
            await functions.FunctionHandler(createRequest, context);

            // 登録データを読み取り
            var read = new Study
            {
                Id = expected.Id,
                StudyEndTime = expected.StudyEndTime,
                CrudType = Enum.EnumCrudType.CrudType.Read
            };
            string body = JsonConvert.SerializeObject(read);
            var request = new APIGatewayProxyRequest() { Body = body };
            var response = await functions.FunctionHandler(request, context);
            var actual = JsonConvert.DeserializeObject<Model.Study>(response.Body);

            //比較
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.StudyEndTime.ToString("yyyyMMddHHmmss"), actual.StudyEndTime.ToString("yyyyMMddHHmmss"));
            Assert.Equal(expected.StudyPlace, actual.StudyPlace);

            Assert.Single(actual.Subjects);
            Assert.Equal(expected.Subjects.Single().StudyContent, actual.Subjects.Single().StudyContent);
            Assert.Equal(expected.Subjects.Single().StudyMinutes, actual.Subjects.Single().StudyMinutes);
            Assert.Equal(expected.Subjects.Single().SubjectName, actual.Subjects.Single().SubjectName);
        }

        [Fact]
        public async void DynamoDBCrudFunctionのUpdate機能テスト()
        {
            // データを登録
            var before = new Study
            {
                Id = new Random().Next(1, 100000000),
                StudyEndTime = DateTime.Now,
                StudyPlace = "教室",
                Subjects = new List<Subject>
                {
                    new Subject
                    {
                        SubjectName = "国語",
                        StudyMinutes = 60,
                        StudyContent = "漢字のお勉強",
                    }
                },
                CrudType = Enum.EnumCrudType.CrudType.Create,
            };
            string createBody = JsonConvert.SerializeObject(before);
            var createRequest = new APIGatewayProxyRequest() { Body = createBody };
            await functions.FunctionHandler(createRequest, context);

            // 登録データを更新
            var expected = new Study
            {
                Id = before.Id,
                StudyEndTime = before.StudyEndTime,
                StudyPlace = "自宅",
                Subjects = new List<Subject>
                {
                    new Subject
                    {
                        SubjectName = "数学",
                        StudyMinutes = 60,
                        StudyContent = "計算のお勉強",
                    }
                },
                CrudType = Enum.EnumCrudType.CrudType.Update
            };
            string body = JsonConvert.SerializeObject(expected);
            var request = new APIGatewayProxyRequest() { Body = body };
            var response = await functions.FunctionHandler(request, context);

            //登録データを取得
            var dbContext = new DynamoDBContext(awsClient);
            var queryConfig = new QueryOperationConfig();
            var queryFilter = new QueryFilter();
            queryFilter.AddCondition(nameof(dynamoEntity.Study.Id), QueryOperator.Equal, expected.Id);
            queryFilter.AddCondition(nameof(dynamoEntity.Study.StudyEndTime), QueryOperator.Equal, expected.StudyEndTime);
            queryConfig.Filter = queryFilter;
            queryConfig.Limit = 1;
            var actual = await dbContext.FromQueryAsync<dynamoEntity.Study>(queryConfig).GetNextSetAsync();

            //比較
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
            Assert.Single(actual);
            Assert.Equal(expected.Id, actual.Single().Id);
            Assert.Equal(expected.StudyEndTime.ToString("yyyyMMddHHmmss"), actual.Single().StudyEndTime.ToString("yyyyMMddHHmmss"));
            Assert.Equal(expected.StudyPlace, actual.Single().StudyPlace);

            Assert.Single(actual.Single().Subjects);
            Assert.Equal(expected.Subjects.Single().StudyContent, actual.Single().Subjects.Single().StudyContent);
            Assert.Equal(expected.Subjects.Single().StudyMinutes, actual.Single().Subjects.Single().StudyMinutes);
            Assert.Equal(expected.Subjects.Single().SubjectName, actual.Single().Subjects.Single().SubjectName);
        }

        [Fact]
        public async void DynamoDBCrudFunctionのDelete機能テスト()
        {
            // データを登録
            var before = new Study
            {
                Id = new Random().Next(1, 100000000),
                StudyEndTime = DateTime.Now,
                StudyPlace = "教室",
                Subjects = new List<Subject>
                {
                    new Subject
                    {
                        SubjectName = "国語",
                        StudyMinutes = 60,
                        StudyContent = "漢字のお勉強",
                    }
                },
                CrudType = Enum.EnumCrudType.CrudType.Create,
            };
            string createBody = JsonConvert.SerializeObject(before);
            var createRequest = new APIGatewayProxyRequest() { Body = createBody };
            await functions.FunctionHandler(createRequest, context);

            // データを削除
            var expected = new Study
            {
                Id = before.Id,
                StudyEndTime = before.StudyEndTime,
                CrudType = Enum.EnumCrudType.CrudType.Delete
            };
            string body = JsonConvert.SerializeObject(expected);
            var request = new APIGatewayProxyRequest() { Body = body };
            var response = await functions.FunctionHandler(request, context);

            //登録データを取得
            var dbContext = new DynamoDBContext(awsClient);
            var queryConfig = new QueryOperationConfig();
            var queryFilter = new QueryFilter();
            queryFilter.AddCondition(nameof(dynamoEntity.Study.Id), QueryOperator.Equal, expected.Id);
            queryFilter.AddCondition(nameof(dynamoEntity.Study.StudyEndTime), QueryOperator.Equal, expected.StudyEndTime);
            queryConfig.Filter = queryFilter;
            queryConfig.Limit = 1;
            var actual = await dbContext.FromQueryAsync<dynamoEntity.Study>(queryConfig).GetNextSetAsync();

            //比較
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
            Assert.Empty(actual);
        }
    }
}
