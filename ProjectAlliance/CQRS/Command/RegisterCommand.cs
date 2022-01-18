

using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectAlliance.Data;
using ProjectAlliance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BCryptNet = BCrypt.Net.BCrypt;
using System.Threading.Tasks;
 
namespace ProjectAlliance.CQRS.Command
{
    public class RegisterCommand : IRequest<object>
    {
        public int id { set; get; }
        public string name { set; get; }
        public string password { set; get; }
        public string userName { set; get; }
        public string email { set; get; }
        public string phone { set; get; }
        public string role { set; get; }
        public string onlineStatus { set; get; }

        public string company { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<RegisterCommand, object>
        {
            private ApiDbContext dbContext;
            public CreateProductCommandHandler(ApiDbContext context)
            {
                this.dbContext = context;
            }
            public async Task<object> Handle(RegisterCommand command, CancellationToken cancellationToken)
            {

                var VerifyEmail =await dbContext.Users
                           .Where(s => s.email == command.email)
                           .FirstOrDefaultAsync();
                var VerifyCompany = dbContext.Company
                          .Where(s => s.companyName == command.company)
                          .FirstOrDefault();
                if (VerifyCompany != null)
                {
                    object res = new
                    {
                        message = "Company Already Exists.",
                        status=400
                    };

                    return res;
                }

                if (VerifyEmail != null)
                {
                    object res = new
                    {
                        message = "email Already Exists.",
                        status = 400
                    };

                    return res;
                }
                else
                {
                    var VerifyUserName = dbContext.Users
                          .Where(s => s.userName == command.userName)
                          .FirstOrDefault();
                    if (VerifyUserName != null)
                    {
                        object raes = new
                        {
                            message = "UserName Already Exists.",
                            status = 400
                        };

                        return raes;
                    }

                    User user = new User();
                    Company comp = new Company();
                    user.name = command.name;
                    user.email = command.email;
                    user.phone = command.phone;
                    user.userName = command.userName+"@"+command.company+".pa.com";
                    user.role = "admin";
                    user.password = BCryptNet.HashPassword(command.password);
                    comp.companyName = command.company;

                    dbContext.Company.Add(comp);
                    dbContext.SaveChanges();
                    user.companyId = comp.id.ToString();
                    dbContext.Users.Add(user);

                    comp.createdBy = user.userName;
                    dbContext.SaveChanges();

                    var res = new {
                        message="successfully created",
                        status=200
                    };


                    return res;

                }

            }
        }
    }
}