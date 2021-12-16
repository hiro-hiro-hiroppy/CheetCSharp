using DbMigration.Entity;
using EntityWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        [HttpGet]
        [Route("Player/{id}")]
        public async Task<PlayerDto.PlayerGetDto?> GetOnePlayer(int id)
        {
            using (var context = new _MyDbContext())
            {
                var result = await context.Players
                    .Include(x => x.Team)
                    .Include(x => x.School)
                    .Where(x => x.Id == id)
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
                    .FirstOrDefaultAsync();

                return result;
            }
        }
    }
}