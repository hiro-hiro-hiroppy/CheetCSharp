using Amazon.DynamoDBv2;
using AWS.DynamoDB.Entity.Entity;
using System;
using System.Threading.Tasks;

namespace AWS.DynamoDB.Entity.MigrateConsole
{
    /// <summary>
    /// DynamoDBマイグレーション コンソールアプリ
    /// </summary>
    class Program
    {
        private static readonly int ProcessSuccess = 0;
        private static readonly int ProcessError = 1;

        static int Main(string[] args)
        {
            var processResult = ProcessSuccess;

            try
            {
                MainProcess().Wait();
                Console.WriteLine("Dynamoテーブル作成");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                processResult = ProcessError;
            }

            Console.WriteLine("終了");
            return processResult;
        }

        internal static async Task MainProcess()
        {
            await DynamoAccess.CreateSimpleTable<Study>();
        }
    }
}
