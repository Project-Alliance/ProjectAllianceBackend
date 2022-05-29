using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAlliance.Data;
using ProjectAlliance.Models;
using ProjectAlliance.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAlliance.Controllers
{
    [Route("api/[controller]")]
    public class GoalsController : Controller
    {
        // GET: api/values

        private readonly ApiDbContext dbContext;
        public readonly IJwtTokenManager _jwtTokenManage;

        public GoalsController(ApiDbContext _dbContext,IJwtTokenManager _jwtTokenManage)
        {
            this.dbContext = _dbContext;
            this._jwtTokenManage = _jwtTokenManage;
        }
      

        // GET api/values/5
        [Authorize]
        [HttpGet("get/{name}")]
        public async Task<IActionResult> Get(string name)
        {
           
            var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                string userId = _jwtTokenManage.getUserId(claim);
                var permision = dbContext.permisions.Where(s => s.userId == Convert.ToInt16(userId) && (s.permisionTitle == "superUser" || s.permisionTitle == "goalsManagement")).SingleOrDefault();
            if (permision != null && !permision.read)
                {
                    return BadRequest(new { message = "You have not permision to do this" });
                }
            var company = await dbContext.Company.SingleOrDefaultAsync(s => s.companyName == name);
            if(company==null)
            {
                return NotFound(new { message = "organization Not Found" });
            }
            var goals = await dbContext.Goals.Where(s => s.companyId == company.id).ToListAsync();
            if (goals != null)
           
            {
                return Ok(goals);
            }
            return NotFound(new { message = "organization Not Found" });
        }
        [Authorize]
        // POST api/values
        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] Goals value)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                string userId = _jwtTokenManage.getUserId(claim);
                var permision = dbContext.permisions.Where(s => s.userId == Convert.ToInt16(userId) && (s.permisionTitle == "superUser" || s.permisionTitle == "goalsManagement")).SingleOrDefault();
            if (permision != null && !permision.create)
                {
                    return BadRequest(new { message = "You have not permision to do this" });
                }
            if(!ModelState.IsValid)
            {
                return BadRequest(new { message="Some Thing Went Wrong"});
            }

            var org = dbContext.Company.SingleOrDefault(s => s.companyName == value.companyName);
            if (org!=null)
            {
                Goals goals = new Goals();
                goals.goalName = value.goalName;
                goals.goalDescription = value.goalDescription;
                goals.startDate = value.startDate;
                goals.endDate = value.endDate;
                goals.companyId = org.id;
                dbContext.Goals.Add(goals);
                await dbContext.SaveChangesAsync();
                return Ok(new { message = "goals saved Successfully", goal = goals });
            }
            return NotFound(new { message = "Organization not found" });
        }

        // PUT api/values/5
        [Authorize]
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Goals value)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                string userId = _jwtTokenManage.getUserId(claim);
                var permision = dbContext.permisions.Where(s => s.userId == Convert.ToInt16(userId) && (s.permisionTitle == "superUser" || s.permisionTitle == "goalsManagement")).SingleOrDefault();
            if (permision != null && !permision.update)
                {
                    return BadRequest(new { message = "You have not permision to do this" });
                }
            var goals = await dbContext.Goals.SingleOrDefaultAsync(s => s.id == id);
            if(goals!=null)
            {
                goals.goalName = value.goalName;
                goals.goalDescription = value.goalDescription;
                goals.startDate = value.startDate;
                goals.endDate = value.endDate;
                dbContext.Goals.Update(goals);
                await dbContext.SaveChangesAsync();
                return Ok(new { message = "goals Update Successfully", goal = goals });
            }
            return NotFound(new { message = "Goals not found" });

        }

        // DELETE api/values/5
        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                string userId = _jwtTokenManage.getUserId(claim);
                var permision = dbContext.permisions.Where(s => s.userId == Convert.ToInt16(userId) && (s.permisionTitle == "superUser" || s.permisionTitle == "goalsManagement")).SingleOrDefault();
            if (permision != null && !permision.Delete)
                {
                    return BadRequest(new { message = "You have not permision to do this" });
                }
            var goals = await dbContext.Goals.SingleOrDefaultAsync(s => s.id == id);
            if(goals!=null)
            {
                dbContext.Goals.Remove(goals);
               await dbContext.SaveChangesAsync();
                return Ok(new { message = "goals Deleted Successfully"});
            }
            return NotFound(new { message = "Goals not found" });
        }
    }
}
