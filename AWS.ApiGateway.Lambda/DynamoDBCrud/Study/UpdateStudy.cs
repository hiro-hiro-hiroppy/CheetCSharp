using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public class UpdateStudy
    {
        public async Task<HttpStatusCode> UpdateRecord(Model.Study request, AmazonDynamoDBClient client)
        {
            var dbContext = new DynamoDBContext(client);
            var record = await dbContext.LoadAsync<dynamoEntity.Study>(hashKey: request.Id, rangeKey: request.StudyEndTime);
            record.StudyPlace = request.StudyPlace;
            record.Subjects = request.Subjects.Select(x => new dynamoModel.Subject
            {
                StudyContent = x.StudyContent,
                StudyMinutes = x.StudyMinutes,
                SubjectName = x.SubjectName
            }).ToList();
            await dbContext.SaveAsync(record);

            return HttpStatusCode.OK;
        }
    }
}
