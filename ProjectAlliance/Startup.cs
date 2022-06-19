using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectAlliance.Data;
using ProjectAlliance.Middlewares;
using MediatR;
using ProjectAlliance.Services;
using Microsoft.Extensions.Azure;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace ProjectAlliance
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAzureClients(builder => {
                builder.AddBlobServiceClient(Configuration.GetSection("Storage:ConnectionString").Value);
            });
            services.AddTransient<IStorageService, StorageService>();
            services.AddMediatR(typeof(Startup));

            services.AddControllers();
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(jwtOptions =>
            {
                var key = "Pakistan12@gmail.com";
                var KeyBytes = Encoding.ASCII.GetBytes(key);
                jwtOptions.RequireHttpsMetadata = false;
                jwtOptions.SaveToken = true;
                jwtOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(KeyBytes),
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddSingleton(typeof(IJwtTokenManager), typeof(JwtTokenManager));

            services.AddDbContext<ApiDbContext>(options => options.UseMySQL(Configuration.GetConnectionString("Default")));
            //services.AddTransient<VerifySignUp>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            
            app.UseRouting();
            //app.UseMiddleware<VerifySignUp>();
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseCors(x => x
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
         
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
      
    }
}
