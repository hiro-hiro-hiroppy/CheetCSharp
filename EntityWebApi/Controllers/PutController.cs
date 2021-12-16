using DbMigration.Entity;
using EntityWebApi.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPut]
        [Route("Player/{id}")]
        public async Task<int> PutPlayer(int id, PlayerDto.PlayerPutDto player)
        {
            if(id == 0)
            {
                return -1;
            }

            using(var context = new _MyDbContext())
            {
                var result = context.Players.SingleOrDefault(x => x.Id == id);

                if(result == null)
                {
                    return -1;
                }

                result.Name = player.Name;
                result.Position = player.Position;
                result.TeamId = player.TeamId;
                result.SchoolId = player.SchoolId;

                await context.SaveChangesAsync();
                return id;
            }
        }

        [HttpPut]
        [Route("Player2/{id}")]
        public async Task<int> PutPlayer2(int id, PlayerDto.PlayerPutDto player)
        {
            if (id == 0)
            {
                return -1;
            }

            using (var context = new _MyDbContext())
            {
                var updatePlayer = new Player
                { 
                    Id = id,
                    Name = player.Name,
                    Position = player.Position,
                    TeamId = player.TeamId,
                    SchoolId = player.SchoolId,
                };
                
                context.Update(updatePlayer);
                await context.SaveChangesAsync();
                return id;
            }
        }
    }
}