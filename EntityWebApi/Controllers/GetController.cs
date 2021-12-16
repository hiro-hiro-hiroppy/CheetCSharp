using DbMigration.Entity;
using EntityWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        [Route("Players")]
        public async Task<List<PlayerDto.PlayerGetDto>> GetPlayers()
        {
            using (var context = new _MyDbContext())
            {
                var result = await context.Players
                    .Include(x => x.Team)
                    .Include(x => x.School)
                    .Select(x => new PlayerDto.PlayerGetDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Position = x.Position,
                        TeamId = x.TeamId,
                        SchoolId = x.SchoolId,
                        Team = new TeamDto.TeamMasterDto
                        {
                            Id = x.Team.Id,
                            Name = x.Team.Name
                        },
                        School = new SchoolDto.SchoolMasterDto
                        {
                            Id = x.School.Id,
                            Name = x.School.Name
                        },
                    })
                    .ToListAsync();
                ;

                return result;
            }
        }
    }
}