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
    public class DeleteMemeberCommand : IRequest<object>
    {
        public int id { set; get; }
       

        public class DeleteMemeberCommandHandler : IRequestHandler<DeleteMemeberCommand, object>
        {
            private ApiDbContext dbContext;
            public DeleteMemeberCommandHandler(ApiDbContext context)
            {
                this.dbContext = context;
            }
            public async Task<object> Handle(DeleteMemeberCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var DeleteMember = dbContext.Users.Where(s => s.id == command.id).FirstOrDefault();
                    if (DeleteMember != null)
                    {
                        dbContext.Users.Remove(DeleteMember);
                        await dbContext.SaveChangesAsync();
                        return new { message= "Deleted Successfully", status= 200 };
                    }
                    else
                    {
                        return new { message= "User not exists", status= 404 };
                    }
                }
                catch(Exception ex)
                {
                    return new { message= "Badrequest\n" + ex.Message, status= 500};
                }
            }
        }
    }
}