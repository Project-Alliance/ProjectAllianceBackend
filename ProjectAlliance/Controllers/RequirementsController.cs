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
    public class RequirementsController : Controller
    {
        // GET: api/values

        private readonly ApiDbContext dbContext;
        public readonly IJwtTokenManager _jwtTokenManage;

        public RequirementsController(ApiDbContext _dbContext,IJwtTokenManager _jwtTokenManage)
        {
            this.dbContext = _dbContext;
            this._jwtTokenManage = _jwtTokenManage;
        }
      

        // GET api/values/5
        [Authorize]
        [HttpPost("create/{projectId}")]
        public async Task<IActionResult> Create(int projectId,[FromBody]Requirements value)
        {
          
           try{
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claim = identity.Claims;
            string userId = _jwtTokenManage.getUserId(claim);
            var permision = dbContext.ProjectTeams.Where(s => s.uid == Convert.ToInt16(userId) &&  s.pid == projectId && s.role == "Requirement Engineer").SingleOrDefault();
            if(permision==null)
            {
                return BadRequest(new { message = "You have not permision, only Requirement Engineer can do this task" });
            }
            Requirements req=new Requirements();
            req.name = value.name;
            req.status = value.status;
            req.requirementDescription = value.requirementDescription;
            req.uid= Convert.ToInt16(userId);
            req.ProjectId=projectId;
            dbContext.requirements.Add(req);
            await dbContext.SaveChangesAsync();
            return Ok(new { message = "Requirement Created" });
           }
           catch(Exception ex){
               return Ok(new { message = ex.Message });
           }
        }
        [Authorize]
        [HttpGet("get/{projectId}")]
        public async Task<IActionResult> Get(int projectId)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                string userId = _jwtTokenManage.getUserId(claim);
                var req = await dbContext.requirements.Where(s => s.ProjectId == projectId).ToListAsync();
                return Ok(req);
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("update/{reqId}")]
        public async Task<IActionResult> Update(int reqId,[FromBody]Requirements value)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                string userId = _jwtTokenManage.getUserId(claim);
                var permision = dbContext.ProjectTeams.Where(s => s.uid == Convert.ToInt16(userId) && s.pid == value.ProjectId && s.role == "Requirement Engineer").SingleOrDefault();
                if (permision == null)
                {
                    return BadRequest(new { message = "You have not permision, only Requirement Engineer can perform requirement update" });
                }
                var req = await dbContext.requirements.Where(s => s.id == reqId).SingleOrDefaultAsync();
                if(req==null)
                {
                    return BadRequest(new { message = "Requirement not found" });
                }
                req.name = value.name;
                req.status = value.status;
                req.requirementDescription = value.requirementDescription;
                dbContext.requirements.Update(req);
                await dbContext.SaveChangesAsync();
                return Ok(new { message = "Requirement Updated" });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }
        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int reqId,int projectId)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                string userId = _jwtTokenManage.getUserId(claim);
                var permision = dbContext.ProjectTeams.Where(s => s.uid == Convert.ToInt16(userId) && s.pid == projectId && s.role == "Requirement Engineer").SingleOrDefault();
                if (permision == null)
                {
                    return BadRequest(new { message = "You have not permision, only Requirement Engineer can perform requirement delete" });
                }
                var req = await dbContext.requirements.Where(s => s.id == reqId).SingleOrDefaultAsync();
                if(req==null)
                {
                    return BadRequest(new { message = "Requirement not found" });
                }
                dbContext.requirements.Remove(req);
                await dbContext.SaveChangesAsync();
                return Ok(new { message = "Requirement Deleted" });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

  }
}
