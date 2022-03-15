using System;
using System.Threading.Tasks;

namespace AWS.S3.MigrateConsole
{
    /// <summary>
    /// S3マイグレーション コンソールアプリ
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
                Console.WriteLine("S3バケット作成");
            }
            catch (Exception e)
            {
               Console.WriteLine(e);
                processResult = ProcessError;
            }

            Console.WriteLine("終了");
            return processResult;
        }

        internal static async Task MainProcess()
        {
            // 獲得したバケットの作成
            await S3Buckets.CreateAllBucketsAsync();
        }
    }
}
