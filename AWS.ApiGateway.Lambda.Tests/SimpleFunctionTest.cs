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

namespace AWS.ApiGateway.Lambda.Tests
{
    public class SimpleFunctionTest
    {
        public SimpleFunctionTest()
        {
        }

        [Fact]
        public void SimpleFunction‚ÌƒeƒXƒg()
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
