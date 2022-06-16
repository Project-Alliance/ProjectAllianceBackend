using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectAlliance.Data;
using ProjectAlliance.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAlliance.Controllers
{
    [Route("api/[controller]")]
    public class ScheduleController : Controller
    {
        ApiDbContext dbContext;

        public ScheduleController(ApiDbContext dbcontext)
        {
            dbContext = dbcontext;
        }
      

 
        [HttpGet("{pid}")]
        public  IActionResult Get(int pid)
        {
            List<object> Sch = new List<object>();
            var Schedules = dbContext.Schedule.Where(s => s.ProjectId == pid).ToList();
            if(Schedules !=null)
            {
                foreach(var Schedule in Schedules)
                {
                    var user = dbContext.Users.SingleOrDefault(s => s.id == Schedule.AssignTo);

                    Schedule.dependencies = Schedule.dependancies;

                    Schedule.assigedTo = new
                    {
                        name = user.name,
                        email = user.email,
                        id = user.id,
                    };
                     
                    Sch.Add(Schedule);
                }
                return Ok(Sch);
            }
            return BadRequest(new { message = "Scedule Not Found" });
        }

        // POST api/values
        [HttpPost("create/{pid}")]
        public async Task<IActionResult> Post(int pid,[FromBody] ProjectSchedule value)
        {
           
            var project = dbContext.Projects.SingleOrDefault(s => s.pid == pid);
            if(project!=null)
            {
                ProjectSchedule sch = new ProjectSchedule();
                sch.name = value.name;
                sch.progress = value.progress;
                sch.ProjectId = value.ProjectId;
                sch.start = value.start;
                sch.end = value.end;
                sch.AssignTo = value.AssignTo;
                sch.dependancies = value.dependancies;
                dbContext.Schedule.Add(sch);
                await dbContext.SaveChangesAsync();
                return Ok(new { message = "Scedule created successfully" });
            }
            return BadRequest(new { message = "Scedule Not Saved" });
        }

        // PUT api/values/5
        [HttpPut("update/{sid}")]
        public async Task<IActionResult> Put(int sid, [FromBody] ProjectSchedule value)
        {
            var sch = dbContext.Schedule.SingleOrDefault(s => s.id == sid);
            if (sch != null)
            {
                sch.name = value.name;
                sch.progress = value.progress;
                sch.start = value.start;
                sch.end = value.end;
                sch.dependancies = value.dependancies;

                dbContext.Schedule.Update(sch);
                await dbContext.SaveChangesAsync();
                return Ok(new { message = "Scedule Updated successfully" });
            }
            return BadRequest(new { message = "Scedule Not Saved" });
        }

        // DELETE api/values/5
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int sid)
        {
            var sch = dbContext.Schedule.SingleOrDefault(s => s.id == sid);
            if (sch != null)
            {
                dbContext.Schedule.Remove(sch);
                await dbContext.SaveChangesAsync();
                return Ok(new { message = "Scedule Deleted successfully" });
            }
            return BadRequest(new { message = "Scedule Not Saved" });
        }
    }
}


