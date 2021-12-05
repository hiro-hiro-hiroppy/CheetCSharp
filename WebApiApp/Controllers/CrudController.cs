using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using WebApiApp.Models;
using MvcApp.Controllers;

namespace WebApiApp.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CrudController : ControllerBase
    {
        protected readonly ILogger<CrudController> _logger;

        public CrudController(ILogger<CrudController> logger)
        {
            this._logger = logger;
        }

        [HttpGet]
        public async Task<CrudModels> Get()
        {
            var crud = await Task.Run(() =>
            {
                return new CrudModels()
                {
                    Id = 1,
                    CrudValue = "Get",
                    HttpStatusCode = HttpStatusCode.OK
                };
            });
            return crud;
        }

        [HttpPost("{id}")]
        public async void Post(int id)
        {
            await Task.Run(() => Console.WriteLine(id));
        }

        [HttpPut("{id}")]
        public async void Put(int id)
        {
            await Task.Run(() => Console.WriteLine(id));
        }

        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await Task.Run(() => Console.WriteLine(id));
        }
    }
}