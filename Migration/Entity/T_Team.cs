using System.ComponentModel.DataAnnotations;

namespace Migration.Entity
{
    /// <summary>
    /// チームテーブル
    /// </summary>
    public class T_Team
    {
        public int TeamId{get;set;}
        
        public string TeamName{get;set;}
        
        public List<T_Player> Players{get;set;}
        
    }
}