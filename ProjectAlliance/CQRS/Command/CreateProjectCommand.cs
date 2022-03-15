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
using ProjectAlliance.TeamTypes;

namespace ProjectAlliance.CQRS.Command
{
    public class CreateProjectCommand : IRequest<object>
    {
        public int pid { get; set; }
        public string ProjectTitle { get; set; }
        public string projectDescription { get; set; }
        public string status { get; set; }
        public string progress { get; set; }
        public DateTime CreateAt { get; set; }
        public string company { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public List <TeamType> team { get; set; }

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
                    var TEAM = new ProjectTeam();
                    var project = new Project();
                    project.ProjectTitle = command.ProjectTitle;
                    project.projectDescription = command.projectDescription;
                    project.status = command.status;
                    project.progress = "0";
                    project.CreateAt = DateTime.Now;
                    var company = await dbContext.Company.Where(s => s.companyName == command.company).FirstOrDefaultAsync();
                    if(company!=null)
                    {
                        project.companyProject = company.id.ToString();
                        
                    }
                    else{
                        return new { message = "Company not exist", status = 404 };
                    }
                    project.startDate = command.startDate;
                    project.endDate = command.endDate;
                    dbContext.Add(project);
                    await dbContext.SaveChangesAsync();
                    foreach(var team in command.team)
                    {
                        TEAM.pid = project.pid;
                        TEAM.uid = team.value;
                        TEAM.role = team.role;
                        dbContext.Add(TEAM);
                    }
                    await dbContext.SaveChangesAsync();
                    return new { message = "successfully created project",status=200,project };
                }
                catch (Exception ex) {
                    return new { message = "error "+ ex, status = 400 };
                }
            }
        }
    }
}