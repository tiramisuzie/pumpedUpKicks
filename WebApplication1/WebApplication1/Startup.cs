using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PumpedUpKicks.Data;
using PumpedUpKicks.Models;
using PumpedUpKicks.Models.Handlers;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();

            builder.AddUserSecrets<Startup>();

            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = true;
            })
                .AddEntityFrameworkStores<ApplicationDBContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<ShoesDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ProductionShoeConnection")));

            services.AddDbContext<ApplicationDBContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("ProductionIdentityConnection")));

            services.AddAuthorization(options => {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole(UserRoles.Admin));
                options.AddPolicy("EmailPolicy", policy => policy.Requirements.Add(new RequireEmailRequirement()));
            });
            services.AddScoped<IAuthorizationHandler, VipEmailRequirement>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
