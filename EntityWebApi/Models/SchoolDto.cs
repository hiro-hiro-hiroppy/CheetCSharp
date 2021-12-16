namespace EntityWebApi.Models
{
    public class SchoolDto
    {
        public class SchoolMasterDto
        {
            /// <summary>
            /// 学校ID
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// 学校名
            /// </summary>
            public string Name { get; set; } = string.Empty;
        }
    }
}
