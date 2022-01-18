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
        public int pid { get; set; }
        public string ProjectTitle { get; set; }
        public string projectDescription { get; set; }
        public string status { get; set; }
        public string progress { get; set; }
        public byte[] CreateAt { get; set; }
        public string company { get; set; }
        public byte[] startDate { get; set; }
        public byte[] endDate { get; set; }

        public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, object>
        {
            private ApiDbContext dbContext;
            public CreateProjectCommandHandler(ApiDbContext context)
            {
                this.dbContext = context;
            }
            public async Task<object> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var project = new Projects();
                    project.ProjectTitle = command.ProjectTitle;
                    project.projectDescription = command.projectDescription;
                    project.status = command.status;
                    project.progress = "0";
                    project.CreateAt = BitConverter.GetBytes(DateTime.Now.ToBinary());
                    var company = await dbContext.Company.Where(s => s.companyName == command.company).FirstOrDefaultAsync();
                    if(company!=null)
                        project.companyProject = company.id.ToString();
                    project.startDate = command.startDate;
                    project.endDate = command.endDate;
                    dbContext.Add(project);
                    await dbContext.SaveChangesAsync();
                    return new { message = "successfully created project",staus=200 };
                }
                catch (Exception ex) {
                    return new { message = "error "+ ex, staus = 400 };
                }
            }
        }
    }
}