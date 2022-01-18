using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectAlliance.CQRS.Command;
using ProjectAlliance.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAlliance.Controllers
{
    [Route("api/[controller]")]
    public class AddMembersController : ApiController
    {
        //private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly UserManager<IdentityUser> _userManager;
        private IMediator mediator;
        public AddMembersController(IMediator mediatr)
        {
            this.mediator = mediatr;
        }


        [HttpPost]
        public async Task<IActionResult> AddMember([FromBody] AddMemeberCommand command)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            return CustomResponse(await mediator.Send(command));
        }

        
        
    }
}
