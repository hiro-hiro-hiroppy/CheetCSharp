using Amazon.DynamoDBv2.DataModel;
using AWS.DynamoDB.Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWS.DynamoDB.Entity.Entity
{
    /// <summary>
    /// Studyテーブル
    /// </summary>
    [DynamoDBTable("Study")]
    public class Study
    {
        /// <summary>
        /// ID
        /// パーティションキー(ハッシュキー)
        /// </summary>
        [DynamoDBHashKey]
        public int Id { get; set; }

        /// <summary>
        /// 勉強終了時刻
        /// ソートキー(レンジキー)
        /// </summary>
        [DynamoDBRangeKey]
        public DateTime StudyEndTime { get; set; }

        /// <summary>
        /// 勉強場所
        /// テーブルでは項目名"Place"にマッピングされる
        /// </summary>
        [DynamoDBProperty("Place")]
        public string StudyPlace { get; set; }

        /// <summary>
        /// 教科ごとの内容
        /// </summary>
        [DynamoDBProperty("Subjects")]
        public List<Subject> Subjects { get; set; }

        /// <summary>
        /// テーブルへマッピングされない
        /// </summary>
        [DynamoDBIgnore]
        public string Ignore { get; set; }
    }
}
