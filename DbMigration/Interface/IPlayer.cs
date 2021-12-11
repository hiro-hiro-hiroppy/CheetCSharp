using DbMigration.Enum;

namespace DbMigration.Interface
{
    public interface IPlayer
    {
        /// <summary>
        /// 選手名
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// ポジション
        /// </summary>
        public PositionEnum.Position Position { get; set; }

        /// <summary>
        /// チームID
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// 学校ID
        /// </summary>
        public int SchoolId { get; set; }
    }
}
