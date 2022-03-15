using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;
using AWS.ApiGateway.Lambda.Model;
using AWS.ApiGateway.Lambda.DynamoDBCrud.Study;
using Amazon.DynamoDBv2;

namespace AWS.ApiGateway.Lambda
{
    public class DynamoDBCrudFunction
    {
        private static AmazonDynamoDBClient awsClient;
        
        public DynamoDBCrudFunction()
        {
            awsClient = new AmazonDynamoDBClient(
                new AmazonDynamoDBConfig
                {
                    ServiceURL = "http://localhost:8000",
                    UseHttp = true
                });
        }

        /// <summary>
        /// DynamoDB‚Ö‚ÌCRUD‹@”\ Lambda
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The API Gateway response.</returns>
        public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var studyRequest = JsonConvert.DeserializeObject<Study>(request.Body);
            var status = HttpStatusCode.BadRequest;
            Study responseBody = null;

            switch(studyRequest.CrudType)
            {
                case Enum.EnumCrudType.CrudType.Create:
                    status= await new CreateStudy().CreateRecord(studyRequest, awsClient);
                    break;

                case Enum.EnumCrudType.CrudType.Read:
                    (status, responseBody) = await new ReadStudy().ReadRecord(studyRequest, awsClient);
                    break;

                case Enum.EnumCrudType.CrudType.Update:
                    status = await new UpdateStudy().UpdateRecord(studyRequest, awsClient);
                    break;

                case Enum.EnumCrudType.CrudType.Delete:
                    status = await new DeleteStudy().DeleteRecord(studyRequest, awsClient);
                    break;

                default:
                    break;
            }

            return new APIGatewayProxyResponse
            {
                StatusCode = (int)status,
                Body = responseBody != null ? JsonConvert.SerializeObject(responseBody) : null,
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
        }
    }
}
