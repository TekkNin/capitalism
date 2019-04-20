using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capitalism.Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Capitalism.SharedKernel.Events;
using Capitalism.Logic.Repositories;
using Capitalism.Infrastructure.Repositories;
using Capitalism.Infrastructure;

namespace Capitalism.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            InitIoC();
        }

        public void InitIoC()
        {
            SharedKernel.ObjectFactory.Container.Configure(config =>
            {
                config.Scan(scan =>
                {
                    scan.Assembly("Capitalism.Logic");
                    scan.WithDefaultConventions();
                    scan.IncludeNamespace("Capitalism.Logic.Handlers");
                    scan.ConnectImplementationsToTypesClosing(typeof(IHandle<>));
                });

                config.For(typeof(IPlayerRepository)).Use(typeof(PlayerRepository));
                config.For(typeof(ITownRepository)).Use(typeof(TownRepository));
                config.For(typeof(ITownBuildingRepository)).Use(typeof(TownBuildingRepository));
                config.For(typeof(IDataAccessConfiguration)).Use(new AppConfiguration(this.Configuration));
            });
        }
    }
}
