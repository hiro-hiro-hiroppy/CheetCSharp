using System;
using System.Collections.Generic;
using System.Text;

namespace AWS.ApiGateway.Lambda.Enum
{
    public class EnumCrudType
    {
        public enum CrudType
        {
            /// <summary>
            /// 新規作成
            /// </summary>
            Create,

            /// <summary>
            /// 読み取り
            /// </summary>
            Read,

            /// <summary>
            /// 更新
            /// </summary>
            Update,

            /// <summary>
            /// 削除
            /// </summary>
            Delete,
        }
    }
}
