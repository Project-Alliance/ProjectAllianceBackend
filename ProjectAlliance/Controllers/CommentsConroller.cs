using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectAlliance.Data;
using ProjectAlliance.Models;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using ProjectAlliance.Services;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using System.Net;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAlliance.Controllers
{
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        ApiDbContext dbContext;
        public readonly IJwtTokenManager _jwtTokenManager;


        public CommentsController(ApiDbContext dbcontext, IJwtTokenManager jwtTokenManager) {
            dbContext = dbcontext;
            _jwtTokenManager = jwtTokenManager;
            //_mapper = mapper;
        }

        [Authorize]
        [HttpPost("AddComments")]
        public async Task<IActionResult> AddComments(int reqId,[FromBody] Comments comments)
        {
            if (ModelState.IsValid)
            {   var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                string userId = _jwtTokenManager.getUserId(claim);
                var user = dbContext.Users.Where(s=>s.id==Convert.ToInt16(userId)).FirstOrDefault();
                comments.reqId = reqId;
                comments.userId = user.id;
                comments.comId=Guid.NewGuid().ToString();
                dbContext.comments.Add(comments);
                await dbContext.SaveChangesAsync();
                return Ok(comments);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [Authorize]
        [HttpPost("AddReplies")]
        public async Task<IActionResult> AddReplies(string comId,[FromBody] CommentsReplies commentsReplies)
        {
            if (ModelState.IsValid)
            {   var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                string userId = _jwtTokenManager.getUserId(claim);
                var user = dbContext.Users.Where(s=>s.id==Convert.ToInt16(userId)).FirstOrDefault();
                commentsReplies.userId = user.id;
                commentsReplies.comId=Guid.NewGuid().ToString();
                commentsReplies.parentCommentId=comId;
                dbContext.CommentsReplies.Add(commentsReplies);
                await dbContext.SaveChangesAsync();
                return Ok(commentsReplies);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [Authorize]
        [HttpGet("GetComments")]
        public async Task<IActionResult> GetComments(int reqId)
        {
            var comments = await dbContext.comments.Where(s=>s.reqId==reqId).ToListAsync();
            List<object> commentsList = new List<object>();
            foreach (var item in comments)
            {
                var replies = await dbContext.CommentsReplies.Where(s=>s.parentCommentId==item.comId).ToListAsync();
                var user = await dbContext.Users.Where(s=>s.id==item.userId).FirstOrDefaultAsync();
                List<object> repliesList = new List<object>();
                recursiveFunction(repliesList,replies);
                object comment = new
                {
                    comId = item.comId,
                    userId = Convert.ToString(item.userId),
                    fullName = user.name,
                    avatarUrl = "https://ui-avatars.com/api/name="+user.name+"&background=random",
                    userProfile = "https://ui-avatars.com/api/name="+user.name+"&background=random",
                    text = item.text,
                    replies = repliesList
                };
                commentsList.Add(comment);
            }
            return Ok(commentsList);
        }

           private List<object> recursiveFunction(List<object> commentsList,List<CommentsReplies> replies)
        {
            foreach (var item in replies)
            {
                var user = dbContext.Users.Where(s=>s.id==item.userId).FirstOrDefault();
                var repliesList = dbContext.CommentsReplies.Where(s=>s.parentCommentId==item.comId).ToList();
                var comment = new
                {
                    comId = item.comId,
                    userId = Convert.ToString(item.userId),
                    fullName = user.name,
                    avatarUrl = "https://ui-avatars.com/api/name="+user.name+"&background=random",
                    userProfile = "https://ui-avatars.com/api/name="+user.name+"&background=random",
                    text = item.text,
                    replies = recursiveFunction(new List<object>(),repliesList)
                };
                commentsList.Add(comment);
            }
            return commentsList;
        }


    }
    
}


// Language: csharp
// Path: Controllers/CommentsConroller.cs
// Compare this snippet from Models/CommentsReplies.cs:
// using System;
// using System.Collections.Generic;







