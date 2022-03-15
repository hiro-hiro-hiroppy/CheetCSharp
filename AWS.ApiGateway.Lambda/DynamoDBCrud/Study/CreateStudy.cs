using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using AWS.ApiGateway.Lambda.Model;
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
    /// 新規作成
    /// </summary>
    public class CreateStudy
    {
        /// <summary>
        /// 新規レコードを作成
        /// </summary>
        /// <returns></returns>
        public async Task<HttpStatusCode> CreateRecord(Model.Study request, AmazonDynamoDBClient client)
        {
            var study = new dynamoEntity.Study()
            {
                Id = request.Id,
                StudyEndTime = request.StudyEndTime,
                StudyPlace = request.StudyPlace,
                Subjects = request.Subjects.Select(x => new dynamoModel.Subject
                {
                    StudyContent = x.StudyContent,
                    StudyMinutes = x.StudyMinutes,
                    SubjectName = x.SubjectName
                }).ToList()
            };
            var dbContext = new DynamoDBContext(client);
            await dbContext.SaveAsync(study);
            return HttpStatusCode.OK;
        }
    }
}
