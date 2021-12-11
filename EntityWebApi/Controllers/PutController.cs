using DbMigration.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EntityWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PutController : ControllerBase
    {
        private readonly ILogger<PutController> _logger;

        public PutController(ILogger<PutController> logger)
        {
            _logger = logger;
        }

        [HttpPut(Name = "Put")]
        public async Task PutAction(Player player)
        {









        }
    }
}