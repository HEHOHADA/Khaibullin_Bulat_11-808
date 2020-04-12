using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VKMVC.DB;
using VKMVC.Filter;
using VKMVC.Models;
using VKMVC.Service;
using VKMVC.ViewModels;

namespace VKMVC
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
            services.AddControllersWithViews();
            services.AddDbContext<BloggingContext>();
            services.AddIdentity<UserModel, IdentityRole>()
                .AddEntityFrameworkStores<BloggingContext>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CommentEditTime", policy =>
                    policy.Requirements.Add(new TimeAccessRequirement()));
            });
            services.AddSingleton<IAuthorizationHandler, PostAuthorizationHandler>();
            bool isDev = Environment.GetEnvironmentVariable("ENVIRONMENT") == "Development";
            services.AddSingleton<IMessageSender>(provider =>
            {
                if (isDev) return new EmailService();
                else return new SMSService();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                Environment.SetEnvironmentVariable("ENVIRONMENT", "Development");
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                Environment.SetEnvironmentVariable("ENVIRONMENT", "Production");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}