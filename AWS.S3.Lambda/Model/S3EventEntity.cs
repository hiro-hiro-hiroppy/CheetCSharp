using System;
using System.Collections.Generic;
using System.Text;

namespace AWS.S3.Lambda.Model
{
    /// <summary>
    /// S3イベント格納モデル
    /// </summary>
    public class S3EventEntity
    {
        /// <summary>
        /// バケット名
        /// </summary>
        public string S3BucketName { get; set; }

        /// <summary>
        /// ファイルまでのパス
        /// </summary>
        public string BlobFileName { get; set; }
    }
}
