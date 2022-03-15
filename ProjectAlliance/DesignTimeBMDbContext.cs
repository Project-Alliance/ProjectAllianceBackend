
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;
//using ProjectAlliance.Data;

//namespace ProjectAlliance
//{
//    public class DesignTimeBMDbContext : IDesignTimeDbContextFactory<ApiDbContext>
//    {
//        IConfiguration configuration;
//        public ApiDbContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();
//            // pass your design time connection string here
//            optionsBuilder.UseMySQL(configuration.GetConnectionString("Default"));
//            return new ApiDbContext(optionsBuilder.Options);
//        }

//        ApiDbContext IDesignTimeDbContextFactory<ApiDbContext>.CreateDbContext(string[] args)
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//}

namespace ProjectAlliance
{
    public class Work
    {

        public void Create(string[] args)
        {

        }
    }
}