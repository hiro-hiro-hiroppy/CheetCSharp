using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimpleController : ControllerBase
    {
        private static Dictionary<int, string> _Simples = new Dictionary<int, string>();

        private readonly ILogger<SimpleController> _logger;

        public SimpleController(ILogger<SimpleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var s in _Simples)
            {
                sb.AppendLine($"Key:{s.Key}, Value:{s.Value}");
            }

            return Ok(sb.ToString());
        }


        [HttpGet("{key}")]
        public ActionResult GetOne(int key)
        {
            if (_Simples.TryGetValue(key, out string xxx))
            {
                //何もなし
            }
            else
            {
                return NotFound("指定したキーが登録されていません。");
            }
            return Ok($"Key:{key}, Value:{xxx}");
        }

        [HttpPost("{key}")]
        public ActionResult Post(int key, string value)
        {
            if (_Simples.TryGetValue(key, out string xxx))
            {
                return BadRequest("キーが重複しています。");
            }
            else
            {
                _Simples.Add(key, value);
            }
            return Ok($"Key:{key}, Value:{value}");
        }

        [HttpPut("{key}")]
        public ActionResult Put(int key, string value)
        {
            if (_Simples.TryGetValue(key, out string xxx))
            {
                _Simples[key] = value;
            }
            else
            {
                return NotFound("指定したキーが登録されていません。");
            }
            return Ok($"Key:{key}, Value:{value}");
        }

        [HttpDelete("{key}")]
        public ActionResult Delete(int key)
        {
            if (_Simples.TryGetValue(key, out string xxx))
            {
                _Simples.Remove(key);
            }
            else
            {
                return NotFound("指定したキーが登録されていません。");
            }
            return Ok("OK");
        }
    }
}
