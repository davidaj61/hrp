using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using HRP.DAL.Context;
using HRP.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace HRP.SIte
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region DBContext

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),datamodel=>datamodel.MigrationsAssembly("HRP.DAL"));
            });

            #endregion

            #region Add Scoped

            //services.AddScoped<>()

            #endregion

            #region Add Service
            services.AddIdentity<User, Role>(Options =>
             {
                 Options.Password.RequireDigit = false;
                 Options.Password.RequireUppercase = false;
                 Options.Password.RequireLowercase = false;
                 Options.Password.RequireNonAlphanumeric = false;
             }).AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddMvc(option => option.EnableEndpointRouting = false);


            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
