using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectAlliance.CQRS.Command;
using ProjectAlliance.CQRS.Query;
using ProjectAlliance.Data;
using ProjectAlliance.Models;
using ProjectAlliance.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAlliance.Controllers
{
    [Route("api/[controller]")]
    public class MembersController : ApiController
    {
        //private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly UserManager<IdentityUser> _userManager;
        private IMediator mediator;
        ApiDbContext dbContext;
        public readonly IJwtTokenManager _jwtTokenManager;
        public MembersController(IMediator mediatr, IJwtTokenManager jwtTokenManager, ApiDbContext _dbContext)
        {
            this.mediator = mediatr;
            this._jwtTokenManager = jwtTokenManager;
            this.dbContext = _dbContext;
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> AddMember([FromBody] AddMemeberCommand command)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            // Gets list of claims.
            IEnumerable<Claim> claim = identity.Claims;
            string userId = _jwtTokenManager.getUserId(claim);
            if (userId != null)
            {
                var permision = dbContext.permisions.Where(s => s.userId == Convert.ToInt16(userId) && (s.permisionTitle == "superUser" || s.permisionTitle == "manageMembers")).SingleOrDefault();
                if (permision!=null&&permision.create)
                {
                    if (!ModelState.IsValid) return CustomResponse(ModelState);
                    return CustomResponse(await mediator.Send(command));
                }
                else return BadRequest(new { message = "You have not permision to do this add members" });
            }
            else
                return BadRequest("unauthroized user");
            
        }
        [Authorize]
        [HttpGet("get/{id}")]
        
        public async Task<IActionResult> GetMembers(string id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            // Gets list of claims.
            IEnumerable<Claim> claim = identity.Claims;
            string userId=_jwtTokenManager.getUserId(claim);
            if (userId != null)
            {
                var permision = dbContext.permisions.Where(s => s.userId == Convert.ToInt16(userId)&&(s.permisionTitle== "superUser" || s.permisionTitle=="manageMembers")).SingleOrDefault();
                if (permision != null && permision.read)
                    return CustomResponse(await mediator.Send(new GetMembersQuery { company = id }));
                else return BadRequest(new { message  = "Not allowed" });
            }
            else
                return BadRequest("unauthroized user");
        }
        [Authorize]
        [HttpDelete("delete/{id}")]

        public async Task<IActionResult> DeleteMember(int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            // Gets list of claims.
            IEnumerable<Claim> claim = identity.Claims;
            string userId = _jwtTokenManager.getUserId(claim);
            if (userId != null)
            {
                var permision = dbContext.permisions.Where(s => s.userId == Convert.ToInt16(userId) && (s.permisionTitle == "superUser" || s.permisionTitle == "manageMembers")).SingleOrDefault();
                if (permision != null && permision.Delete)
                    return CustomResponse(await mediator.Send(new DeleteMemeberCommand { id = id }));
                    
                else return BadRequest(new { message = "not allwed" });
            }
            else
                return BadRequest("unauthroized user");
            
        }
        [Authorize]
        [HttpPut("update/{id}")]

        public async Task<IActionResult> UpdateMembers(int id,UpdateMemeberCommand command)
        {
            command.id = id;
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            // Gets list of claims.
            IEnumerable<Claim> claim = identity.Claims;
            string userId = _jwtTokenManager.getUserId(claim);
            if (userId != null)
            {
                var permision = dbContext.permisions.Where(s => s.userId == Convert.ToInt16(userId) && (s.permisionTitle == "superUser" || s.permisionTitle == "manageMembers")).SingleOrDefault();
                if (permision != null && permision.read)
                   return CustomResponse(await mediator.Send(command));
                    
                else return BadRequest(new { message = "not allowed" });
            }
            else
                return BadRequest("unauthroized user");
            
        }
       
    }
}
