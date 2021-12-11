using DbMigration.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetOneController : ControllerBase
    {
        private readonly ILogger<GetOneController> _logger;

        public GetOneController(ILogger<GetOneController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}", Name = "GetOne")]
        public async Task<Player?> GetOneAction(int id)
        {
            using (var context = new _MyDbContext())
            {
                var result = await context.Players
                    //.Include(x => x.TeamId)
                    //.Include(x => x.SchoolId)
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                return result;
            }
        }
    }
}