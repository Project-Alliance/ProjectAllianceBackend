using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectAlliance.Data;

namespace ProjectAlliance.CQRS.Query
{
    
      
        public class GetMembersQuery :IRequest<object>
        {


        public string company;
            public class GetMemberQuerryHandler :IRequestHandler<GetMembersQuery,object>
            {
                private ApiDbContext dbContext;
                public GetMemberQuerryHandler(ApiDbContext context)
                {
                    this.dbContext = context;
                }
                public async Task<object> Handle(GetMembersQuery query,CancellationToken cancellationToken)
                {
                try
                {
                    var company = await dbContext.Company.Where(s => s.companyName == query.company).FirstOrDefaultAsync();
                    if (company != null) {
                        var members = await dbContext.Users.Where(s => s.companyId == company.id.ToString()).ToListAsync();
                        Console.WriteLine(members.ToString());
                        return new { status = 200, members };
                    }
                    else
                    {
                        return  new { status = 400, message="company not exist" };
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
