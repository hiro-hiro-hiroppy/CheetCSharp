namespace Migration.Entity
{
    /// <summary>
    /// 選手テーブル
    /// </summary>
    public class T_Player
    {
        public int PlayerId{get;set;}
        
        public int TeamId{get;set;}
        
        public string PlayerName{get;set;}
        
        public int PositionId{get;set;}
        
        public T_Team Team{get;set;}
        
        public M_Position Postion {get;set;}
    }
}