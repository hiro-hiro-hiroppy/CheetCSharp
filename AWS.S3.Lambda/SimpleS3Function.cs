using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.S3Events;
using Amazon.S3;
using Amazon.S3.Util;
using AWS.S3.Lambda.Model;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWS.S3.Lambda
{
    public class SimpleS3Function
    {
        IAmazonS3 S3Client { get; set; }

        /// <summary>
        /// Default constructor. This constructor is used by Lambda to construct the instance. When invoked in a Lambda environment
        /// the AWS credentials will come from the IAM role associated with the function and the AWS region will be set to the
        /// region the Lambda function is executed in.
        /// </summary>
        public SimpleS3Function()
        {
            S3Client = new AmazonS3Client();
        }

        /// <summary>
        /// Constructs an instance with a preconfigured S3 client. This can be used for testing the outside of the Lambda environment.
        /// </summary>
        /// <param name="s3Client"></param>
        public SimpleS3Function(IAmazonS3 s3Client)
        {
            this.S3Client = s3Client;
        }

        /// <summary>
        /// シンプルなS3イベントハンドラー
        /// </summary>
        /// <param name="s3event"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<string> FunctionHandler(S3Event s3event, ILambdaContext context)
        {
            var s3Entity = s3event.Records.Single().S3;
            var request = new S3EventEntity
            {
                S3BucketName = s3Entity.Bucket.Name,
                BlobFileName = s3Entity.Object.Key
            };

            var response = await this.S3Client.GetObjectMetadataAsync(request.S3BucketName, request.BlobFileName);
            return response.Headers.ContentType;
        }
    }
}
