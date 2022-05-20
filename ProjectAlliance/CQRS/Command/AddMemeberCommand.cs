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
            List<Permisions> permisions=new List<Permisions>();
            
            public AddMemeberCommandHandler(ApiDbContext context)
            {
                this.dbContext = context;
                  List<object> list=new List<object>(new []{
                    new {permisionTitle="manageMember",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="manageProjects",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="manageTasks",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="goalsManagement",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="managePermisions",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="manageRoles",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="manageUsers",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="manageReports",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="manageSettings",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="manageNotifications",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="manageCalendar",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="manageFiles",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="manageMessages",read=false,updtae=false,delete=false,create=false},
                    });
            foreach (var item in list)
            {
                permisions.Add(new Permisions()
                {
                    permisionTitle = item.GetType().GetProperty("permisionTitle").GetValue(item).ToString(),
                    read = Convert.ToBoolean(item.GetType().GetProperty("read").GetValue(item)),
                    update = Convert.ToBoolean(item.GetType().GetProperty("updtae").GetValue(item)),
                    Delete = Convert.ToBoolean(item.GetType().GetProperty("delete").GetValue(item)),
                    create = Convert.ToBoolean(item.GetType().GetProperty("create").GetValue(item))
                });
            }
           
            }
            public async Task<object> Handle(AddMemeberCommand command, CancellationToken cancellationToken)
            {

                var VerifyEmail = await dbContext.Users
                           .Where(s => s.email == command.email)
                           .FirstOrDefaultAsync();
                
                var getCompany = dbContext.Company
                          .Where(s => s.companyName == command.company)
                          .FirstOrDefault();
                if (getCompany == null)
                {
                    object res = new
                    {
                        message = "Company Not Exists.",
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
                    user.role = command.role;
                    user.password = BCryptNet.HashPassword(command.password);
                    
                    user.companyId = getCompany.id.ToString();
                    dbContext.Users.Add(user);                 
                    dbContext.SaveChanges();
                    
                    AddPermisionsToNewMembers(user.id,user.role);

                    var res = new
                    {
                        message = "successfully Added Member",
                        status = 200
                    };


                    return res;

                }

            }
            
             public void AddPermisionsToNewMembers(int id,string role){

            if (role == "Moderator")
            {
                foreach (var permision in permisions)
                {
                    permision.create = true;
                    permision.Delete = false;
                    permision.read = true;
                    permision.update = true;
                    permision.userId = id;
                    permision.permisionTitle = permision.permisionTitle;
                    dbContext.permisions.Add(permision);

                }
                dbContext.SaveChanges();
            }
            else{
                foreach (var permision in permisions)
                {
                    permision.create = false;
                    permision.Delete = false;
                    permision.read = true;
                    permision.update = false;
                    permision.userId = id;
                    permision.permisionTitle = permision.permisionTitle;
                    dbContext.permisions.Add(permision);

                }
                dbContext.SaveChanges();
            }
        }
       

        }
    }
}