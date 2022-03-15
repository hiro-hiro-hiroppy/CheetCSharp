using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using dynamoEntity = AWS.DynamoDB.Entity.Entity;
using dynamoModel = AWS.DynamoDB.Entity.Model;

namespace AWS.ApiGateway.Lambda.DynamoDBCrud.Study
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteStudy
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> DeleteRecord(Model.Study request, AmazonDynamoDBClient client)
        {
            var dbContext = new DynamoDBContext(client);
            await dbContext.DeleteAsync<dynamoEntity.Study>(hashKey: request.Id, rangeKey: request.StudyEndTime);
            return HttpStatusCode.OK;
        }
    }
}
