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
    public class AddMemeberCommand : IRequest<object>
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

        public class AddMemeberCommandHandler : IRequestHandler<AddMemeberCommand, object>
        {
            private ApiDbContext dbContext;
            public AddMemeberCommandHandler(ApiDbContext context)
            {
                this.dbContext = context;
            }
            public async Task<object> Handle(AddMemeberCommand command, CancellationToken cancellationToken)
            {

                var VerifyEmail = await dbContext.Users
                           .Where(s => s.email == command.email)
                           .FirstOrDefaultAsync();
                Console.WriteLine(command.company);
                var getCompany = dbContext.Company
                          .Where(s => s.companyName == command.company)
                          .FirstOrDefault();
                if (getCompany == null)
                {
                    object res = new
                    {
                        message = "Company Nota Exists.",
                        status = 400
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
                    
                    user.name = command.name;
                    user.email = command.email;
                    user.phone = command.phone;
                    user.userName = command.userName + "@" + command.company.ToLower() + ".pa.com";
                    user.role = "employee";
                    user.password = BCryptNet.HashPassword(command.password);
                    
                    user.companyId = getCompany.id.ToString();
                    dbContext.Users.Add(user);

                    
                    dbContext.SaveChanges();

                    var res = new
                    {
                        message = "successfully Added Member",
                        status = 200
                    };


                    return res;

                }

            }
        }
    }
}