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
    public class CreateProjectCommand : IRequest<object>
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

        public class AddMemeberCommandHandler : IRequestHandler<CreateProjectCommand, object>
        {
            private ApiDbContext dbContext;
            public AddMemeberCommandHandler(ApiDbContext context)
            {
                this.dbContext = context;
            }
            public async Task<object> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
            {
                return command;
            }
        }
    }
}