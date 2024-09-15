using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using BookReadingApp.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using BookReadingApp.Application.Interfaces;
using BookReadingApp.Infrastructure.Repository;
using Microsoft.Extensions.Logging;
using FacadePattern.FacadeDP;
using FacadePattern.FacadeFactory;
using FacadePattern.FacadeFactoryInterface;
using FacadePattern.FacadeInterface;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace BookReadingWebApp
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
            services.AddHealthChecks()
                .AddSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                      name: "SQL Server",
                      failureStatus: HealthStatus.Unhealthy,
                      tags: new[] { "readiness" });
            //Add Logging As a singleton
            services.AddSingleton<ILogger>(provider =>
            {
                var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
                return loggerFactory.CreateLogger("MyLogger");
            });
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(option =>
            {
                option.Password.RequiredLength = 5;
                option.Password.RequiredUniqueChars = 1;
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = true;
                option.Password.RequireUppercase = true;
                option.Password.RequireNonAlphanumeric = false;
            });

            services.AddControllersWithViews();


            //Repository Design Pattern
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();


            //Facade Design Pattern
            services.AddScoped<IFacade, Facade>();
            services.AddScoped<ICommentFacade, CommentFacade>();
            services.AddScoped<IEventFacade, EventFacade>();
            services.AddScoped<IFacadeFactory, FacadeFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ApplyMigration(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    //app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");

                endpoints.MapHealthChecks("/ready", new HealthCheckOptions
                {
                    Predicate = (check) => check.Tags.Contains("readiness"), 
                    ResponseWriter = async (context, report) =>
                    {
                        context.Response.ContentType = "text/plain";
                        var status = report.Status == HealthStatus.Healthy ? "Healthy" : "Unhealthy";
                        var description = report.Status == HealthStatus.Healthy
                            ? "SQL Server is reachable."
                            : "Unable to connect to SQL Server.";

                        await context.Response.WriteAsync($"{status}\n{description}");
                    }
                });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Event}/{action=Events}/{id?}");
            });

        }

        private void ApplyMigration(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (dbContext.Database.GetPendingMigrations().Any())
                {
                    dbContext.Database.Migrate();
                }
            }
        }
    }
}
