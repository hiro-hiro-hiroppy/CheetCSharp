namespace DbMigration.Entity
{
    /// <summary>
    /// 選手テーブル
    /// </summary>
    public class T_PLAYER
    {
        public int PlayerId { get; set; }

        public int TEAM_ID { get; set; }

        public string? PLAYER_NAME { get; set; }

        public int POSITION_ID { get; set; }

        public T_TEAM? TEAM { get; set; }

        public M_POSITION? POSITION { get; set; }
    }
    
    public class T_PLAYER_CONFIG
    {

    }
}