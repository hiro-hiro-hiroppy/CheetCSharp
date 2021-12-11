namespace DbMigration.Interface
{
    public interface ISchool
    {
        /// <summary>
        /// 学校ID
        /// </summary>
        public int Id { get; set; }

        /// 学校名
        /// </summary>
        public string? Name { get; set; }
    }
}
