using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAlliance.CQRS.Command;



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
        public async Task<ActionResult> CreateProject([FromBody] CreateProjectCommand runOperationCommand)
        {
            
            return CustomResponse(await mediator.Send(runOperationCommand));
        }

        //[HttpPost("upload")]
        //public ActionResult uploadDocument(IFormFile file)
        //{

        //    try
        //    {
        //        storageServices.Upload(file);
        //        return Ok((message: "uplaoded", StatusCode: 200));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest((ex));
        //    }
        //}

    }
}

