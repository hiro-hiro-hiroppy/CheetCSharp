using DbMigration.Entity;
using EntityWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("Player")]
        public async Task<int> PostPlayer(PlayerModel player)
        {
            using (var context = new _MyDbContext())
            {
                var result = await context.Players.AddAsync(new Player()
                {
                    Name = player.Name,
                    Position = player.Position,
                    TeamId = player.TeamId,
                    SchoolId = player.SchoolId,
                });

                await context.SaveChangesAsync();
                return result.Entity.Id;
            }
        }
    }
}