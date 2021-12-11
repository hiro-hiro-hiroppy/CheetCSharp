using Microsoft.AspNetCore.Mvc;
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

        [HttpDelete("{id}", Name = "Delete")]
        public async Task<dynamic> DeleteAction(int id)
        {
            return await Task.Run(() => HttpStatusCode.OK);
        }
    }
}