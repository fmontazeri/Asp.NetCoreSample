using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAspDotNetCore.CustomRouteConstraints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstAspDotNetCore.Data;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace FirstAspDotNetCore
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
            services.AddRouting(option =>
            {
                option.ConstraintMap.Add("weekday", typeof(WeekDayConstraint));
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromSeconds(300);
                option.Cookie.HttpOnly = true;
                option.Cookie.Name = "FirstSession";

            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(System.IO.Path.Combine(env.ContentRootPath,"node_modules")) ,
                    RequestPath ="/node_modules"
                });
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
            app.UseSession();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                //Pay attention to urls are created by routing pipeline in page Home/Index

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                //**********************************************
                //routes.MapRoute(
                //    name: "route1",
                //    template: "{controller}/{action}/{id?}",
                //    defaults: new { Controller = "Home", Action = "Index" });
                //***********************************************
                //routes.MapRoute(
                //    name: "route2",
                //    template: "{controller}/{action}/{id?}",
                //    defaults: new { Controller = "Home", Action = "Index" } ,
                //    constraints: new{ id = new IntRouteConstraint()});
                //OR
                //routes.MapRoute(
                //    name: "route2",
                //    template: "{controller}/{action}/{id:int?}",
                //    defaults: new {Controller = "Home", Action = "Index"});
                //************************************************
                //routes.MapRoute(
                //    name: "route2",
                //    template: "{controller}/{action}/{id?}",
                //    defaults: new { Controller = "Home", Action = "Index" },
                //    constraints: new { id = new RangeRouteConstraint(10,30) });
                //
                //OR
                //routes.MapRoute(
                //    name: "route2",
                //    template: "{controller}/{action}/{id:range(10,30)?}",
                //    defaults: new {Controller = "Home", Action = "Index"});
                //*************************************************
                //routes.MapRoute(
                //    name: "route3",
                //    template: "{controller}/{action}/{id?}",
                //    defaults: new { Controller = "Home", Action = "Index" },
                //    constraints: new { id = new BoolRouteConstraint() });
                //OR
                //routes.MapRoute(
                //    name: "route3",
                //    template: "{controller}/{action}/{id:bool?}",
                //    defaults: new {Controller = "Home", Action = "Index"});
                //***********************************************
                //routes.MapRoute(
                //    name: "route1",
                //    template: "{controller}/{action}/{id?}",
                ////Check Both of theme and see what happen
                //    defaults: new { Controller = "Home", Action = "Index" },
                //    //defaults: new { Controller = "Session", Action = "Get" },
                //    constraints: new { Controller = new RegexRouteConstraint("^S.*") });
                //OR
                //routes.MapRoute(
                //    name: "route1",
                //    template: "{controller:regex(^H.*$)=Home}/{action=Index}/{id?}");//,
                ////    defaults: new {Controller = "Home", Action = "Index"});
                //AND
                //routes.MapRoute(
                //    name: "route1",
                //    template: "{controller=Home}/{action:regex(^Index$|^Index2$)=Index}/{id?}");
                //***************************************************
                //routes.MapRoute(
                //    name: "route1",
                //    template: "{controller}/{action}/{id?}",
                //    defaults: new { Controller = "Home", Action = "Index" });
                ////--> /1   /hello
                //routes.MapRoute(
                //    name: "route4",
                //    template: "{controller}/{action}/{id}/{title}",
                //    defaults: new { Controller = "Home", Action = "Index" },
                //    constraints: new
                //    {
                //        id = new CompositeRouteConstraint(new IRouteConstraint[]
                //        {
                //           new IntRouteConstraint(),
                //           new RangeRouteConstraint(1,long.MaxValue)
                //        }),
                //        title = new CompositeRouteConstraint(new IRouteConstraint[]
                //        {
                //            new AlphaRouteConstraint(),
                //            new MinLengthRouteConstraint(3),
                //        })
                //    });
                //-->200  /1  /hello  /1/hello
                //-->404  /hello/hello  /hello/124  
                //*********************************************
                //routes.MapRoute(
                //    name: "route1",
                //    template: "{controller}/{action}/{id?}",
                //    defaults: new { Controller = "Home", Action = "Index" });
                //routes.MapRoute(
                //    name: "Route5",
                //    template: "OldCtrl/{action}/{id?}",
                //    defaults: new {Controller="Session" });

                ////Old address : /OldCtrl/Get
                ////New address : /Session/Get
                //********************* Custom Constraint *********************************
                //routes.MapRoute(
                //    name: "route1",
                //    template: "{controller}/{action}/{id?}",
                //    defaults: new { Controller = "Home", Action = "Index" },
                //    constraints:new{id=new WeekDayConstraint()});
                //OR
                //// It's service added to servies (ConfigureServices method)
                //routes.MapRoute(
                //    name: "route1",
                //    template: "{controller}/{action}/{id:weekday?}",
                //    defaults: new {Controller = "Home", Action = "Index"});

                ////200 /home/index/fri
                ////404  /home/index/hello
                //*******************************************
            });
        }
    }
}
