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
                Permisions userPermision = new Permisions();
                userPermision.permisionTitle = "superUser";
                userPermision.create = true;
                userPermision.update = true;
                userPermision.Delete = true;
                userPermision.read = true;
                userPermision.userId = user.id;
                dbContext.permisions.Add(userPermision);
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
                    string accessToken = _jwtTokenManager.Authenticate(user.userName,user.id,user.role);

                    var company = dbContext.Company.Where(s => s.id == Convert.ToInt16(user.companyId)).FirstOrDefault();
                    var Permisions = dbContext.permisions.Where(s => s.userId == user.id).ToList();

                    var res = new {
                        id=user.id,
                        name=user.name,
                        email=user.email,
                        userName=user.userName,
                        accessToken=accessToken,
                        phone = user.phone,
                        role = user.role,
                        company= company.companyName,
                        permisions=Permisions,
                        profilePic=user.profilePic!=null?"http://localhost:5000/api/Document/FileAPI/"+user.profilePic:"https://ui-avatars.com/api/name="+user.name+"&background=random"
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
       
       [HttpPost("forgotPassword")]
         public IActionResult ForgotPassword(string UserName)
        {
            var user = dbContext.Users
                       .Where(s => s.userName == UserName)
                       .FirstOrDefault();
            if(user != null)
            {
                string password = "P"+user.name+Math.Floor(new Random().NextDouble() * 1000000);
                string email = user.email;
                string userName = user.userName;
                string name = user.name;
                user.password=BCryptNet.HashPassword(password);
                dbContext.Users.Update(user);
                dbContext.SaveChanges();
                string company = dbContext.Company.Where(s => s.id == Convert.ToInt16(user.companyId)).FirstOrDefault().companyName;
                string subject = "Password Recovery";
                string body = "Hi "+name+",<br/><br/>"+"Your Password is: "+password+"<br/><br/>"+"Regards,<br/>"+company;
                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("as1265513@gmail.com");
                mailMessage.To.Add(new MailAddress(email));
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "as1265513@gmail.com",
                        Password = "qlfdaliohvbbltxu"
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(mailMessage);
                }

                object res = new
                {
                    message = "Password Sent to your Email.",
                    status = 200
                };
                return Ok(res);
            }
            else
            {
                object res = new
                {
                    message = "Email Not Found.",
                    status = 404
                };
                return NotFound(res);
            }
        }
       [Authorize]
       [HttpPut("updatePassword")]
         public IActionResult UpdatePassword([FromBody] User value)
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
                            message = "Invalid Password!",
                            status = 400
                        };
                        return BadRequest(res);
                    }
                    else
                    {
                        user.password = BCryptNet.HashPassword(value.newPassword);
                        dbContext.Users.Update(user);
                        dbContext.SaveChanges();
                        object res = new
                        {
                            message = "Password Updated Successfully.",
                            status = 200
                        };
                        return Ok(res);
                    }
                }
                else
                {
                    object res = new
                    {
                        message = "User Not found.",
                        status = 404
                    };
                    return NotFound(res);
                }
         }
       
        [Authorize]
        [HttpPut("updateProfile")]
        public IActionResult UpdateProfile(string userName,[FromForm] User value)
        {
            var user = dbContext.Users
                       .Where(s => s.userName == userName)
                       .FirstOrDefault();
            if(user != null)
            {
                user.name = value.name;
                user.email = value.email;
                user.phone = value.phone;
                dbContext.Users.Update(user);
                dbContext.SaveChanges();
                if(value.ProfilePicture != null)
                {
                      // Getting Image
                    var file = value.ProfilePicture;

                    //Getting FileName
                    var fileName = Path.GetFileName(file.FileName);
                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);
                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), "Files", fileExtension);

                    // Saving Image on Server
                    if (file.Length > 0)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", newFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {

                            file.CopyTo(fileStream);
                        }
                        user.profilePic = newFileName;
                        dbContext.Users.Update(user);
                        dbContext.SaveChanges();
                        
                    }
          
                }
                object res = new
                {
                    message = "Profile Updated Successfully.",
                    status = 200
                };
                return Ok(res);
            }
            else
            {
                object res = new
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











