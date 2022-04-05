using System;
using System.Collections.Generic;
using System.Linq;
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



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAlliance.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : ApiController
    {
        readonly private IMediator mediator;
        readonly private ApiDbContext dbContext;

        public ProjectController(IMediator mediator, ApiDbContext _dbContext)
        {
            dbContext = _dbContext;
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            
        }
        // GET: api/values
        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectCommand runOperationCommand)
        {
            
            return CustomResponse(await mediator.Send(runOperationCommand));
        }
        [Authorize]
        [HttpGet("get/{company}")]

        public async Task<IActionResult> GetProjects(string company)
        {

            
         return CustomResponse(await mediator.Send(new GetAllProjectsQuerry { company = company }));
           
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
                    object MemberData = new
                    {
                        role = teams.role,
                        name = membersData.name,
                        email = membersData.email,
                        userId=teams.uid

                    };
                    team.Add(membersData);
                }
                return Ok(team);
            }
            else
            {
                return BadRequest(new { message="NO Member Found Please Add member to you team" });
            }

        }

    }
}

