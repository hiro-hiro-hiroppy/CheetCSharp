namespace EntityWebApi.Models
{
    public class TeamDto
    {
        public class TeamMasterDto
        {
            /// <summary>
            /// チームID
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// チーム名
            /// </summary>
            public string Name { get; set; } = string.Empty;
        }
    }
}
