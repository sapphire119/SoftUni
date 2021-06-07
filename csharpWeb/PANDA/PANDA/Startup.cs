using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Panda.Data;
using Panda.Filters;
using Panda.Filters.Options;
using Panda.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Panda
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
            services.AddDbContext<PandaDbContext>(options =>
            {
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging();
            });

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews(options =>
            {
                //Global Filter Attribute
                //options.Filters.Add(new AddHeaderAttribute("X-Global", "We are one.")); 
                options.Filters.Add<MyActionFilter>(/*int.MinValue*/);
                options.Filters.Add<MyResourceFilter>();
                options.Filters.Add<MyExceptionFilter>();
                options.Filters.Add<MyAuthorizeFilter>();
                options.Filters.Add<MyResultFilter>();
                //options.Filters.Add();
            });

            //services.AddTransient<ICounterService, CounterService>();
            //services.AddScoped<ICounterService, CounterService>();

            //Options Pattern https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-5.0
            services.Configure<PositionOptions>(
                Configuration.GetSection("Position"));

            services.AddScoped<MyActionFilterAttribute>();

            services.AddSingleton<ICounterService, CounterService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //var a = app;
            //var b = env;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(/*new DeveloperExceptionPageOptions { SourceCodeLineCount = 100 }*/);

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseStatusCodePages("text/plain", "Status code page, status code: {0}");

            //app.UseStatusCodePages(async context =>
            //{
            //    context.HttpContext.Response.ContentType = "text/plain";

            //    await context.HttpContext.Response.WriteAsync("Status code page, status code: " + context.HttpContext.Response.StatusCode);
            //});

            //app.UseStatusCodePagesWithRedirects("/MyStatusCode/{0}");
            //app.UseStatusCodePagesWithRedirects("/MyStatusCode");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            

            app.UseEndpoints(routes =>
            {
                //routes.MapControllerRoute(
                //    name: "error",
                //    pattern: "MyStatusCode/{code}",
                //    defaults: new { controller = "Home", action = "MyStatusCode" });
                
                //routes.MapControllerRoute(
                //    name: "error",
                //    pattern: "MyStatusCode",
                //    defaults: new { controller = "Home", action = "MyStatusCode" });
                routes.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
