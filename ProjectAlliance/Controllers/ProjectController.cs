using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAlliance.CQRS.Command;
using ProjectAlliance.CQRS.Query;
using ProjectAlliance.Data;
using ProjectAlliance.Models;
using ProjectAlliance.Services;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAlliance.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : ApiController
    {
        readonly private IMediator mediator;
        readonly private ApiDbContext dbContext;
        public readonly IJwtTokenManager _jwtTokenManage;

        public ProjectController(IMediator mediator, ApiDbContext _dbContext,IJwtTokenManager _jwtTokenManage)
        {
            dbContext = _dbContext;
            this._jwtTokenManage = _jwtTokenManage;
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            
        }
        // GET: api/values
        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectCommand runOperationCommand)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claim = identity.Claims;
            string userId = _jwtTokenManage.getUserId(claim);
            if (userId != null)
            {
                var permision = dbContext.permisions.Where(s => s.userId == Convert.ToInt16(userId) && (s.permisionTitle == "superUser" || s.permisionTitle == "manageProjects")).SingleOrDefault();
                if (permision != null && permision.create)
                {
                    if (!ModelState.IsValid) return CustomResponse(ModelState);
                    return CustomResponse(await mediator.Send(runOperationCommand));
                }
                else return BadRequest(new { message = "You have not permision to do this add members" });
            }
            else
                return BadRequest("unauthroized user");
            
        }
        [Authorize]
        [HttpGet("get/{company}")]

        public async Task<IActionResult> GetProjects(string company)
        {

        var identity = HttpContext.User.Identity as ClaimsIdentity;
        IEnumerable<Claim> claim = identity.Claims;
        string userId = _jwtTokenManage.getUserId(claim);
        if (userId != null)
        {
            var permision = dbContext.permisions.Where(s => s.userId == Convert.ToInt16(userId) && (s.permisionTitle == "superUser" || s.permisionTitle == "manageProjects")).SingleOrDefault();
            if (permision != null && permision.read)
            {
                if (!ModelState.IsValid) return CustomResponse(ModelState);
                 return CustomResponse(await mediator.Send(new GetAllProjectsQuerry { company = company }));
            }
            else return BadRequest(new { message = "You have not permision to do this add members" });
        
           
        }
         return BadRequest("unauthroized user");
        }

        [Authorize]
        [HttpGet("getProjectTeam/{id}")]

        public async Task<IActionResult> GetProjectTeam(int id)
        {
            List<object> team = new List<object>();
            var projectTeam = await dbContext.ProjectTeams.Where(s => s.pid == id).ToListAsync();
            if (projectTeam != null)
            {
                foreach (ProjectTeam teams in projectTeam)
                {
                    var membersData = dbContext.Users.SingleOrDefault(s => s.id == teams.uid);
                    if (membersData != null)
                    {
                        object MemberData = new
                        {
                            role = teams.role,
                            name = membersData.name,
                            email = membersData.email,
                            uid = teams.uid,
                            pid = teams.pid,
                            id=teams.id,
                            membersData.userName

                        };
                        team.Add(MemberData);
                    }
                    else
                    {
                        return BadRequest(new { message = "Member dose not exist in team" });

                    }
                }
                return Ok(team);
            }
            else
            {
                return BadRequest(new { message="NO Member Found Please Add member in your team" });
            }

        }

        [Authorize]
        [HttpPost("AddProjectTeam/{pid}")]
        public async Task<IActionResult> EditProjectTeam(int pid,[FromBody] ProjectTeam[] value )
        {
            var project =await dbContext.Projects.SingleOrDefaultAsync(s => s.pid == pid);
            List <ProjectTeam> team = new List<ProjectTeam>();
            if (project!=null)
            {
               foreach(var user in value)
                {
                    ProjectTeam pt = new ProjectTeam() {
                        pid = project.pid,
                        role = user.role,
                        uid = user.id
                };  
                    team.Add(pt);
                }
               await dbContext.ProjectTeams.AddRangeAsync(team);
                await dbContext.SaveChangesAsync();
                return Ok(new { message = "added Successfully",value,team });
            }
            return BadRequest(new { message = "Project Not found" });
        }


        [Authorize]
        [HttpPut("updateteam/{teamid}")]
        public async Task<IActionResult> EditProjectTeam(int teamid,[FromBody] ProjectTeam value)
        {
            var team = await dbContext.ProjectTeams.SingleOrDefaultAsync(s => s.id == teamid);
            if(team!=null)
            {
                team.role = value.role;
                dbContext.ProjectTeams.Update(team);
                await dbContext.SaveChangesAsync();
                return Ok(new { messsage = "Updated successfully" });
            }
            return BadRequest(new { messsage = "Team member not found" });
        }


        [Authorize]
        [HttpDelete("reomoveteam/{teamid}")]
        public async Task<IActionResult> RemoveProjectTeam(int teamid)
        {
            var team = await dbContext.ProjectTeams.SingleOrDefaultAsync(s => s.id == teamid);
            if (team != null)
            {
              
                dbContext.ProjectTeams.Remove(team);
                await dbContext.SaveChangesAsync();
                return Ok(new { messsage = "Removed successfully" });
            }
            return BadRequest(new { messsage = "Team member not found" });
        }

    }

}

