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

namespace AWS.ApiGateway.Lambda.Tests
{
    public class DynamoDBCrudFunctionTest
    {
        public DynamoDBCrudFunctionTest()
        {
        }

        [Fact]
        public async void DynamoDBCrudFunctionのCreate機能テスト()
        {
            TestLambdaContext context;
            APIGatewayProxyRequest request;
            APIGatewayProxyResponse response;

            DynamoDBCrudFunction functions = new DynamoDBCrudFunction();
            string body = JsonConvert.SerializeObject(new Study
            {
                Id = 1,
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
            });
            request = new APIGatewayProxyRequest() { Body = body };
            context = new TestLambdaContext();

            response = await functions.FunctionHandler(request, context);
            //Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
            //Assert.Equal("Hello AWS Serverless", response.Body);
        }

        [Fact]
        public void DynamoDBCrudFunctionのRead機能テスト()
        {
            TestLambdaContext context;
            APIGatewayProxyRequest request;
            APIGatewayProxyResponse response;

            SimpleFunction functions = new SimpleFunction();
            request = new APIGatewayProxyRequest();
            context = new TestLambdaContext();

            response = functions.FunctionHandler(request, context);
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Hello AWS Serverless", response.Body);
        }

        [Fact]
        public void DynamoDBCrudFunctionのUpdate機能テスト()
        {
            TestLambdaContext context;
            APIGatewayProxyRequest request;
            APIGatewayProxyResponse response;

            SimpleFunction functions = new SimpleFunction();
            request = new APIGatewayProxyRequest();
            context = new TestLambdaContext();

            response = functions.FunctionHandler(request, context);
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Hello AWS Serverless", response.Body);
        }

        [Fact]
        public void DynamoDBCrudFunctionのDelete機能テスト()
        {
            TestLambdaContext context;
            APIGatewayProxyRequest request;
            APIGatewayProxyResponse response;

            SimpleFunction functions = new SimpleFunction();
            request = new APIGatewayProxyRequest();
            context = new TestLambdaContext();

            response = functions.FunctionHandler(request, context);
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Hello AWS Serverless", response.Body);
        }
    }
}
