namespace DbMigration.Entity
{
    /// <summary>
    /// ポジションマスタ
    /// </summary>
    public class M_POSITION
    {
        public int POSITION_ID { get; set; }

        public string? POSITION_NAME { get; set; }

        public T_PLAYER? PLAYER { get; set; }
    }

    public class M_POSITION_CONFIG
    {

    }
}