using System.Net;
namespace WebApiApp.Models
{
    public class CrudModels
    {
        /// <summary>
        /// ID
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        
        /// <summary>
        /// 値
        /// </summary>
        /// <value></value>
        public string? CrudValue {get;set;}
        
        /// <summary>
        /// HttpStatus
        /// </summary>
        /// <value></value>
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}