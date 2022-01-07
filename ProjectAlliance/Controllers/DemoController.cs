using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAlliance.Controllers
{
    [Route("api/[controller]")]
    public class DemoController : Controller
    {

        [Produces("text/plain")]
        [HttpGet("demo1")]
        public IActionResult Demo1()
        {
            try
            {
                var content = "Hello World";
                return Ok(content);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("text/html")]
        [HttpGet("demo2")]
        public IActionResult Demo2()
        {
            try
            {
                var content = "<b><i><u>Hello World</u></i></b>";
                return new ContentResult
                {
                    Content = content,
                    ContentType = "text/html",
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch
            {
                return BadRequest();
            }
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
