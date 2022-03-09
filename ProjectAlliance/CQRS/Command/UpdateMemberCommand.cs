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
    public class UpdateMemeberCommand : IRequest<object>
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

        public class UpdateMemeberCommandHandler : IRequestHandler<UpdateMemeberCommand, object>
        {
            private ApiDbContext dbContext;
            public UpdateMemeberCommandHandler(ApiDbContext context)
            {
                this.dbContext = context;
            }
            public async Task<object> Handle(UpdateMemeberCommand command, CancellationToken cancellationToken)
            {
                var user = await dbContext.Users.Where(s=>s.id==command.id).FirstOrDefaultAsync();
                if(user == null)
                {
                    return (message: "User Not exist", status: 200);
                }
                else
                {
                    user.name=command.name;
                    user.role=command.role;
                    user.phone = command.phone;
                    dbContext.SaveChanges();
                    return (message: "Successfully Updated", status: 200);
                }
            }
        }
    }
}