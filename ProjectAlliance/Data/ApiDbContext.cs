using System;
using Microsoft.EntityFrameworkCore;
using ProjectAlliance.Models;

namespace ProjectAlliance.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext()
        {
        }

        public ApiDbContext(DbContextOptions<ApiDbContext>options):base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<SubTasks> SubTasks { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<ProjectTeam> ProjectTeams { get; set; }

        public DbSet<DocumentSection> documentSection { get; set; }
        public DbSet<ProjectDocument> projectDocument { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<Goals> Goals { get; set; }
        public DbSet<ProjectSchedule> Schedule { get; set; }

         public DbSet<QualitySchedule> QualitySchedule { get; set; }
        public DbSet<Permisions> permisions { get; set; }
        public DbSet<Requirements> requirements { get; set; }
        public DbSet<RequirementModule> RequirementsModule { get; set; }
        public DbSet<RequirementAttachment> RequirementAttachments { get; set; }

        public DbSet<Design> Designs { get; set; }
        public DbSet<DesignAttachment> DesignAttachments { get; set; }
        public DbSet<DesignFolder> folders { get; set; }

        public DbSet<Enviorment> enviornment { get; set; }

        public DbSet<LabResource> labResource { get; set; }
        public DbSet<TestCases> testCases { get; set; }
        public DbSet<TestPlan> testPlan { get; set; }
        public DbSet<TestResult> testResult { get; set; }
        public DbSet<TestCaseAttachment> TestCaseAttachment { get; set; }


         public DbSet<Comments> comments { get; set; }
        public DbSet<CommentsReplies> CommentsReplies { get; set; }
         public DbSet<BoardLane> boardlane { get; set; }
        public DbSet<BoardCard> boardCard { get; set; }


        public DbSet<RecevidMail> mail { get; set; }
        public DbSet<EmailAttachment> mailAttachments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           //modelBuilder.Entity<ProjectTeam>(e => e.HasNoKey());

        }
    }
}
