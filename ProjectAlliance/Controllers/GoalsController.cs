using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAlliance.Data;
using ProjectAlliance.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAlliance.Controllers
{
    [Route("api/[controller]")]
    public class GoalsController : Controller
    {
        // GET: api/values

        private readonly ApiDbContext dbContext;

        public GoalsController(ApiDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [Authorize]
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var goals = await dbContext.Goals.Where(s => s.companyId == id).ToListAsync();
            if (goals != null)
            {
                return Ok(goals);
            }
            return NotFound(new { message = "organization Not Found" });
        }

        // POST api/values
        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] Goals value)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new { message="Some Thing Went Wrong"});
            }
            var org = dbContext.Company.SingleOrDefault(s => s.id == value.companyId);
            if (org!=null)
            {
                Goals goals = new Goals();
                goals.goalName = value.goalName;
                goals.goalDescription = value.goalDescription;
                goals.statingDate = value.statingDate;
                goals.endingDate = value.endingDate;
                goals.companyId = org.id;
                dbContext.Goals.Add(goals);
                await dbContext.SaveChangesAsync();
                return Ok(new { message = "goals saved Successfully", goal = goals });
            }
            return NotFound(new { message = "Organization not found" });
        }

        // PUT api/values/5
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Goals value)
        {
            var goals = await dbContext.Goals.SingleOrDefaultAsync(s => s.id == id);
            if(goals!=null)
            {
                goals.goalName = value.goalName;
                goals.goalDescription = value.goalDescription;
                goals.statingDate = value.statingDate;
                goals.endingDate = value.endingDate;
                dbContext.Goals.Update(goals);
                await dbContext.SaveChangesAsync();
                return Ok(new { message = "goals Update Successfully", goal = goals });
            }
            return NotFound(new { message = "Goals not found" });

        }

        // DELETE api/values/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
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
