using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAlliance.CQRS.Command;
using ProjectAlliance.CQRS.Query;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAlliance.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : ApiController
    {
        readonly private IMediator mediator;
        
        public ProjectController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            
        }
        // GET: api/values
        [HttpPost("create")]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectCommand runOperationCommand)
        {
            
            return CustomResponse(await mediator.Send(runOperationCommand));
        }

        [HttpGet("GetCompanyProjects/{company}")]

        public async Task<IActionResult> GetProjects(string company)
        {

            
         return CustomResponse(await mediator.Send(new GetAllProjectsQuerry { company = company }));
           
        }

    }
}

