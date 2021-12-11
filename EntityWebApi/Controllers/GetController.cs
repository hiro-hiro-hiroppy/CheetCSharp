using DbMigration.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EntityWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetController : ControllerBase
    {
        private readonly ILogger<GetController> _logger;

        public GetController(ILogger<GetController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Get")]
        public async Task<List<Player>> GetAction()
        {
            using (var context = new _MyDbContext())
            {
                var result = await context.Players
                    .Include(x => x.Team)
                    .Include(x => x.School)
                    .Select(x => new Player
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Position = x.Position,
                        TeamId = x.TeamId,
                        SchoolId = x.SchoolId,
                        Team = new Team { 
                            Id = x.Team.Id, 
                            Name = x.Team.Name 
                        },
                        School = new School { 
                            Id = x.School.Id
                            , Name = x.School.Name 
                        },
                    })
                    .ToListAsync();
                ;

                return result;
            }
        }

        [HttpGet]
        [Route("XYZ")]
        public async Task<List<Team>> GetAction2()
        {
            using (var context = new _MyDbContext())
            {
                var result = await context.Teams
                    .Include(x => x.Player)
                    .ThenInclude(x => x.School)
                    .Select(x => new Team { 
                        Id = x.Id,
                        Name = x.Name,
                        Player = x.Player.Select(x => new Player
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Position = x.Position,
                            TeamId = x.TeamId,
                            SchoolId = x.SchoolId,
                            School = new School
                            {
                                Id = x.School.Id
                            ,
                                Name = x.School.Name
                            },
                        }).ToList()
                    })
                    .ToListAsync();
                ;

                return result;
            }
        }
    }
}