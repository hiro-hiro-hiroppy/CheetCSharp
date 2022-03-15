using AWS.ApiGateway.Lambda.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWS.ApiGateway.Lambda.Model
{
    /// <summary>
    /// Studyモデル
    /// </summary>
    public class Study
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 勉強終了時刻
        /// </summary>
        public DateTime StudyEndTime { get; set; }

        /// <summary>
        /// 勉強場所
        /// </summary>
        public string StudyPlace { get; set; }

        /// <summary>
        /// 教科ごとの内容
        /// </summary>
        public List<Subject> Subjects { get; set; }

        /// <summary>
        /// CRUDの種類
        /// </summary>
        public EnumCrudType.CrudType CrudType { get; set; }
    }
}
