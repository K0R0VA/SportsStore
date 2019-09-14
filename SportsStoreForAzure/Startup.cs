using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SportsStoreForAzure.Models.Class.Cart;
using SportsStoreForAzure.Models.DbContext;
using SportsStoreForAzure.Models.Interfaces;
using SportsStoreForAzure.Models.Repository;
using SportsStoreForAzure.Models.Seed;

namespace SportsStoreForAzure
{
    public class Startup
    {
        readonly IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder().
                SetBasePath(env.ContentRootPath).
                AddJsonFile("appsettings.json").
                AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true).
                Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>
                (option => option.UseSqlServer(Configuration["Data:SportsStoreProducts:ConnectionString"]));
            services.AddDbContext<AppIdentityDbContext>
                (option => option.UseSqlServer(Configuration["Data:SportsStoreIdentity:ConnectionString"]));
            services.AddIdentity<IdentityUser, IdentityRole>().
                AddEntityFrameworkStores<AppIdentityDbContext>();
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddSession();
            services.AddScoped(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();
            services.AddMemoryCache();
        }

        [Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory looger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseIdentity();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Error",
                    template: "Error",
                    defaults: new { controller = "Error", action = "Error" });
                routes.MapRoute(
                    name: null,
                    template: "{category}/Page{page:int}",
                    defaults: new { Controller = "Product", action = "Index" });
                routes.MapRoute(
                    name: null,
                    template: "Page{page:int}",
                    defaults: new { Controller = "Product", action = "Index", page = 1 });
                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new { Controller = "Product", action = "Index", page = 1 });
                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { Controller = "Home", action = "Index", page = 1 });
                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            }
             );
            using (var Scope = app.ApplicationServices.CreateScope())
            {
                ApplicationDbContext context = Scope.ServiceProvider.
                    GetRequiredService<ApplicationDbContext>();
                UserManager<IdentityUser> userManager = Scope.ServiceProvider.
                    GetRequiredService<UserManager<IdentityUser>>();
                SeedData.EnsurePopulated(context);
                IdentitySeedData.EnsurePopulated(userManager).Wait();
            }
        }
    }
}
