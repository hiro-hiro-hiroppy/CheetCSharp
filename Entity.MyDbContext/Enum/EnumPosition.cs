using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.MyDbContext.Enum
{
    /// <summary>
    /// ポジション Enumクラス
    /// </summary>
    public class EnumPosition
    {
        /// <summary>
        /// ポジション
        /// </summary>
        public enum Position
        {
            Pitcher = 1,
            Catcher = 2,
            First = 3,
            Second = 4,
            Third = 5,
            Short = 6,
            Left = 7,
            Center = 8,
            Right = 9,
        }
    }
}
