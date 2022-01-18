using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAlliance.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : ApiController
    {
        private IMediator mediator;
        public ProjectController(IMediator mediator)
        {
            mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        }
        // GET: api/values
        [HttpPost]
        public Task<ActionResult> CreateProject()
        {

        }
    }
}
