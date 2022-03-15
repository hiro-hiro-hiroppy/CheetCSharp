using Amazon.Runtime;
using Amazon.S3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.S3.MigrateConsole
{
    internal static class S3Buckets
    {
        private static readonly AmazonS3Client AwsS3Client = new AmazonS3Client(
            new BasicAWSCredentials("accessKey", "secretKey"),
            new AmazonS3Config
            {
                ServiceURL = "http://localhost:5000",
                UseHttp = true,
                ForcePathStyle = true,
                AuthenticationRegion = "ap-northeast-1",
            });

        private static readonly string[] bucketNames = new string[] { "test-bucket" };

        /// <summary>
        /// S3バケットを全て作成する
        /// </summary>
        /// <param name="bucketNames"></param>
        /// <returns></returns>
        public static async Task CreateAllBucketsAsync()
        {
            await Task.WhenAll(bucketNames.Select(async b =>
            {
                await AwsS3Client.PutBucketAsync(b);
                Console.WriteLine($"S3バケット {b} 作成");
            }).ToList());
        }
    }
}
