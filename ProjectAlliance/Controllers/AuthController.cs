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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAlliance.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        ApiDbContext dbContext;
      


        public AuthController(ApiDbContext dbcontext) {
            dbContext = dbcontext;
            //_mapper = mapper;
        }


        private static List<User> user = new List<User>()
        {
            new User(){id=0,name="Azeem",userName="as1265513",password="Pakistan12",email="as1265513@gmail.com"},
           
        };


        [HttpGet("Login")]
        public IEnumerable<User> Get()
        {
            return user;
        }


        [HttpPost("signup")]
        public IActionResult Post([FromBody] User value)
        {

            var VerifyEmail = dbContext.Users
                       .Where(s => s.email == value.email)
                       .FirstOrDefault();
            if (VerifyEmail != null)
            {
                object res = new
                {
                    message = "email Already Exists.",
                };

                return BadRequest(res);
            }
            else
            {
                var VerifyUserName = dbContext.Users
                      .Where(s => s.userName == value.userName)
                      .FirstOrDefault();
                if (VerifyUserName != null)
                {
                    object res = new
                    {
                        message = "UserName Already Exists.",
                    };

                    return BadRequest(res);
                }

                User user = new User();
                user = value;
                user.password= BCryptNet.HashPassword(value.password);
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return Ok(value);

            }


        }

        [HttpPost("signin")]
        public IActionResult Login([FromBody] User value)
        {

            var user = dbContext.Users
                       .Where(s => s.userName == value.userName)
                       .FirstOrDefault();
            if(user != null)
            {
                bool comparePassword = BCryptNet.Verify(value.password, user.password);
                if (!comparePassword)
                {
                    var res = new
                    {
                        accessToken= "null",
                        status= 401,
                        message= "Invalid Password!"
                    };
                    return BadRequest(res);
                }
                else
                {
                   string accessToken = generateJwtToken(user);
                    var res = new {
                        id=user.id,
                        name=user.name,
                        email=user.email,
                        userName=user.userName,
                        accessToken=accessToken
                    };
                   
                    return Ok(res);

                }
            }
            else
            {
                var res = new
                {
                    message = "User Not found.",
                    status = 404
                };
                return NotFound(res);
            }

           

            }
        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Pakistan12@gmail.com");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
    
}











