namespace DbMigration.Entity
{
    /// <summary>
    /// チームテーブル
    /// </summary>
    public class T_TEAM
    {
        public int TEAM_ID { get; set; }

        public string? TEAM_NAME { get; set; }

        public List<T_PLAYER>? PLAYER { get; set; }
    }
    
    public class T_TEAM_CONFIG
    {

    }
}