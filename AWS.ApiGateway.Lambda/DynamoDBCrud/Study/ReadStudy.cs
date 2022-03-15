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
    public class ReadStudy
    {
        public async Task<(HttpStatusCode, Model.Study)> ReadRecord(Model.Study request, AmazonDynamoDBClient client)
        {
            var dbContext = new DynamoDBContext(client);
            var record = await dbContext.LoadAsync<dynamoEntity.Study>(hashKey: request.Id, rangeKey: request.StudyEndTime);
            var study = new Model.Study
            {
                Id = record.Id,
                StudyEndTime = record.StudyEndTime,
                StudyPlace = record.StudyPlace,
                Subjects = record.Subjects.Select(x => new Model.Subject
                {
                    StudyContent = x.StudyContent,
                    StudyMinutes = x.StudyMinutes,
                    SubjectName = x.SubjectName
                }).ToList(),
                CrudType = Enum.EnumCrudType.CrudType.Read
            };

            return (HttpStatusCode.OK, study);
        }
    }
}
