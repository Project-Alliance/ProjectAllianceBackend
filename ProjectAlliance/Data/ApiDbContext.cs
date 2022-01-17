using System;
using Microsoft.EntityFrameworkCore;
using ProjectAlliance.Models;

namespace ProjectAlliance.Data
{
    public class ApiDbContext : DbContext
    {
        
        public ApiDbContext(DbContextOptions<ApiDbContext>options):base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<SubTasks> SubTasks { get; set; }
        public DbSet<Tasks> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           //modelBuilder.Entity<User>(e => e.Property(e => e.age).HasColumnType("tinyint(1)").HasConversion<short>());

        }
    }
}
