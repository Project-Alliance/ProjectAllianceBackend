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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(e => e.Property(e => e.age).HasColumnType("tinyint(1)").HasConversion<short>());

        }
    }
}
