using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectAlliance.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAlliance.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
         
        private static List<User> user = new List<User>()
        {
            new User(){id=0,name="Azeem",userName="as1265513",password="Pakistan12",email="as1265513@gmail.com"},
           
        };

        // GET: api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return user;
        }

        // GET api/values/5
        //[HttpGet("{id}")]
        //public IEnumerable<User> Get(User IDa)
        //{
        //    return user.Exists(IDa);
        //}

        // POST api/valuesa
        [HttpPost]
        public void Post([FromBody] User value)
        {
            user.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            user[id] = value;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            user.RemoveAt(id);
        }
    }
}
