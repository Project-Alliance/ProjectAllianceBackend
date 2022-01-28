using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectAlliance.CQRS.Command;
using ProjectAlliance.CQRS.Query;
using ProjectAlliance.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAlliance.Controllers
{
    [Route("api/[controller]")]
    public class MembersController : ApiController
    {
        //private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly UserManager<IdentityUser> _userManager;
        private IMediator mediator;
        public MembersController(IMediator mediatr)
        {
            this.mediator = mediatr;
        }


        [HttpPost("create")]
        public async Task<IActionResult> AddMember([FromBody] AddMemeberCommand command)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            return CustomResponse(await mediator.Send(command));
        }
        [HttpGet("get/{id}")]
        
        public async Task<IActionResult> GetMembers(string id)
        {
            return CustomResponse(await mediator.Send(new GetMembersQuery { company = id }));
        }
        [HttpDelete("delete/{id}")]

        public async Task<IActionResult> DeleteMember(int id)
        {
            return CustomResponse(await mediator.Send(new DeleteMemeberCommand { id = id }));
        }
        [HttpPut("update/{id}")]

        public async Task<IActionResult> UpdateMembers(int id,UpdateMemeberCommand command)
        {
            command.id = id;

            return CustomResponse(await mediator.Send(command);
        }
       
    }
}
