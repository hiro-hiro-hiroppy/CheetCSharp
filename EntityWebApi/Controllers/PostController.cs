using DbMigration.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

        [HttpPost(Name = "Post")]
        public async Task PostAction(Player player)
        {
            using (var context = new _MyDbContext())
            {
                var result = await context.Players.AddAsync(new Player()
                {
                    Name = player.Name,
                    Position = player.Position,
                    TeamId = player.TeamId,
                    SchoolId = player.SchoolId
                });

                context.SaveChanges();
                return;
            }
        }
    }
}