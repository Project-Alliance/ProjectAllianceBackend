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
        public DbSet<Permisions> permisions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           //modelBuilder.Entity<ProjectTeam>(e => e.HasNoKey());

        }
    }
}
