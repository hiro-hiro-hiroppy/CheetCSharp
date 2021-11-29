namespace Migration.Entity
{
    /// <summary>
    /// ポジションマスタ
    /// </summary>
    public class M_Position
    {
        public int PositionId{get;set;}
        
        public string PositionName{get;set;}
        
        public T_Player Player{get;set;}
    }
    
    public class M_PositionConfigure
    {
        
    }
    
}