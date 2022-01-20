using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectAlliance.Data;

namespace ProjectAlliance.CQRS.Query
{


    public class GetAllProjectsQuerry : IRequest<object>
    {


        public string company;
        public class GetAllProjectQuerryHandler : IRequestHandler<GetAllProjectsQuerry, object>
        {
            private ApiDbContext dbContext;
            public GetAllProjectQuerryHandler(ApiDbContext context)
            {
                this.dbContext = context;
            }
            public async Task<object> Handle(GetAllProjectsQuerry query, CancellationToken cancellationToken)
            {
                try
                {
                    var company = await dbContext.Company.Where(s => s.companyName == query.company).FirstOrDefaultAsync();
                    if (company != null)
                    {
                        var projects = await dbContext.Projects.Where(s => s.companyProject == company.id.ToString()).ToListAsync();
                       
                        return new { status = 200, projects };
                    }
                    else
                    {
                        return new { status = 400, message = "company not exist" };
                    }

                }
                catch (Exception ex)
                {
                    return new { status = 400, message = ex };
                }
            }


        }
    }

}
