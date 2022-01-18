
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectAlliance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
 
namespace CQRSMediator.Notifications
{
    public class VerfiyLoginCredential : INotification
    {
        public string email { get; set; }
        public string company { get; set; }
        public string userName { get; set; }
    }

    public class EmailHandler : INotificationHandler<VerfiyLoginCredential>
    {
        private ApiDbContext dbContext;
        public EmailHandler(ApiDbContext context)
        {
            this.dbContext = context;
        }
        public Task Handle(VerfiyLoginCredential notification, CancellationToken cancellationToken)
        {
            
            // send email to customers
            return Task.CompletedTask;
        }
    }

    public class userNameHandler : INotificationHandler<VerfiyLoginCredential>
    {
        private ApiDbContext dbContext;
        public userNameHandler(ApiDbContext context)
        {
            this.dbContext = context;
        }
        public string email { get; set; }
        public Task Handle(VerfiyLoginCredential notification, CancellationToken cancellationToken)
        {

            var user = dbContext.Users.Where(s => s.userName == notification.userName).FirstOrDefaultAsync();
            if(user!=null)
            {
                return Task.CompletedTask;
            }
            
            return Task.CompletedTask;
        }
    }
    public class CompanyHandler : INotificationHandler<VerfiyLoginCredential>
    {
        private ApiDbContext dbContext;
        public CompanyHandler(ApiDbContext context)
        {
            this.dbContext = context;
        }
        public Task Handle(VerfiyLoginCredential notification, CancellationToken cancellationToken)
        {
           
            //send sms to sales team
            return Task.CompletedTask;
        }
    }
}
