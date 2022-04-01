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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAlliance.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        ApiDbContext dbContext;
        public readonly IJwtTokenManager _jwtTokenManager;


        public AuthController(ApiDbContext dbcontext, IJwtTokenManager jwtTokenManager) {
            dbContext = dbcontext;
            _jwtTokenManager = jwtTokenManager;
            //_mapper = mapper;
        }


        private static List<User> user = new List<User>()
        {
            new User(){id=0,name="Azeem",userName="as1265513",password="Pakistan12",email="as1265513@gmail.com"},
           
        };

    
        [HttpGet("user")]
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
            var VerifyCompany = dbContext.Company
                      .Where(s => s.companyName == value.company)
                      .FirstOrDefault();
            if(VerifyCompany!=null)
            {
                object res = new
                {
                    message = "Company Already Exists.",
                    status = 400
                };

                return BadRequest(res);
            }

            if (VerifyEmail != null)
            {
                object res = new
                {
                    message = "email Already Exists.",
                    status = 400
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
                    object ress = new
                    {
                        message = "UserName Already Exists.",
                        status = 400
                    };

                    return BadRequest(ress);
                }

                User user = new User();
                Company comp = new Company();
                user.name = value.name;
                user.email = value.email;
                user.phone = value.phone;
                user.userName = value.userName+"@"+value.company.ToLower()+".pa.com";
                user.role = "admin";
                user.password= BCryptNet.HashPassword(value.password);
                comp.companyName = value.company;

                dbContext.Company.Add(comp);
                dbContext.SaveChanges();
                user.companyId = comp.id.ToString();
                dbContext.Users.Add(user);

                comp.createdBy = user.userName;
                dbContext.SaveChanges();

                object res = new
                {
                    message = "Successfull Crated your account",
                    status=200
                };
                
                return Ok(res);

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
                    string accessToken = _jwtTokenManager.Authenticate(user.userName,user.role);

                    var company = dbContext.Company.Where(s => s.id == Convert.ToInt16(user.companyId)).FirstOrDefault();
                    var res = new {
                        id=user.id,
                        name=user.name,
                        email=user.email,
                        userName=user.userName,
                        accessToken=accessToken,
                        phone = user.phone,
                        role = user.role,
                        company= company.companyName,
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











