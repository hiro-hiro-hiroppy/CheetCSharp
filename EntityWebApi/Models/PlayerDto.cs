using DbMigration.Enum;

namespace EntityWebApi.Models
{
    public class PlayerDto
    {
        public class PlayerMasterDto
        {
            /// <summary>
            /// 選手ID
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// 選手名
            /// </summary>
            public string Name { get; set; } = string.Empty;

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

        public class PlayerGetDto
        {
            /// <summary>
            /// 選手ID
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// 選手名
            /// </summary>
            public string Name { get; set; } = string.Empty;

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

            /// <summary>
            /// チーム
            /// </summary>
            public TeamDto.TeamMasterDto Team { get; set; } = new TeamDto.TeamMasterDto();

            /// <summary>
            /// 出身校
            /// </summary>
            public SchoolDto.SchoolMasterDto School { get; set; } = new SchoolDto.SchoolMasterDto();
        }

        public class PlayerPostDto
        {
            /// <summary>
            /// 選手名
            /// </summary>
            public string Name { get; set; } = string.Empty;

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

        public class PlayerPutDto
        {
            /// <summary>
            /// 選手名
            /// </summary>
            public string Name { get; set; } = string.Empty;

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
}