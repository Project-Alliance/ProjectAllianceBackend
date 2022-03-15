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
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           //modelBuilder.Entity<ProjectTeam>(e => e.HasNoKey());

        }
    }
}
