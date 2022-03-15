using System;
using System.Collections.Generic;
using System.Text;

namespace AWS.ApiGateway.Lambda.Model
{
    /// <summary>
    /// 教科モデル
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// 教科名
        /// </summary>
        public string SubjectName { get; set; }

        /// <summary>
        /// 勉強内容
        /// </summary>
        public string StudyContent { get; set; }

        /// <summary>
        /// 勉強時間(分)
        /// </summary>
        public int StudyMinutes { get; set; }
    }
}
