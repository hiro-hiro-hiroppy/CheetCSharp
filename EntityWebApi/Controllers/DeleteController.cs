using DbMigration.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EntityWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeleteController : ControllerBase
    {
        private readonly ILogger<DeleteController> _logger;

        public DeleteController(ILogger<DeleteController> logger)
        {
            _logger = logger;
        }

        [HttpDelete]
        [Route("Player/{id}")]
        public async Task DeletePlayer(int id)
        {
            using(var context = new _MyDbContext())
            {
                var player = await context.Players.SingleOrDefaultAsync(x => x.Id == id);

                if(player != null)
                {
                    context.Players.Remove(player);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}