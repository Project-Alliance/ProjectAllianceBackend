using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectAlliance.Data;
using ProjectAlliance.Models;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ProjectAlliance.CQRS.Query
{

    public class LoginQuerry : IRequest<object>
    {
      
        public string password { set; get; }
        public string userName { set; get; }
      
        public class LoginQuerryHandler : IRequestHandler<LoginQuerry, object>
        {
            private ApiDbContext dbContext;
            public LoginQuerryHandler(ApiDbContext context)
            {
                this.dbContext = context;
            }
            public async Task<object> Handle(LoginQuerry command, CancellationToken cancellationToken)
            {

                try
                {
                    var user = dbContext.Users
                       .Where(s => s.userName == command.userName)
                       .FirstOrDefault();
                    if (user != null)
                    {
                        bool comparePassword = BCryptNet.Verify(command.password, user.password);
                        if (!comparePassword)
                        {
                            object res = new
                            {
                                accessToken = "null",
                                status = 401,
                                message = "Invalid Password!"
                            };
                            return res;
                        }
                        else
                        {
                            string accessToken = generateJwtToken(user);

                            var company = await dbContext.Company.Where(s => s.id == Convert.ToInt16(user.companyId)).FirstOrDefaultAsync();
                            object res = new
                            {
                                id = user.id,
                                name = user.name,
                                email = user.email,
                                userName = user.userName,
                                accessToken = accessToken,
                                phone = user.phone,
                                role = user.role,
                                company = company.companyName,
                                status=200
                            };

                            return res;

                        }
                    }
                    else
                    {
                        object res = new
                        {
                            message = "User Not found.",
                            status = 404
                        };
                        return res;
                    }
                }
                catch(Exception ex)
                {
                    object res = new
                    {
                        message = "Server error." + ex,
                        status = 404
                    };
                    return res;
                   
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

}
