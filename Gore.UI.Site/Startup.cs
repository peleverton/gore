using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Gore.Infra.CrossCutting.IoC;
using Gore.UI.Site.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Gore.UI.Site
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapperSetup();
            // Add memory cache services
            services.AddMemoryCache();            
            services.AddMvc();

            // Adding MediatR for Domain Events and Notifications
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(Pipelines.MeasureTime<,>));
            services.AddMediatR(typeof(Startup));

            // .NET Native DI Abstraction
            RegisterServices(services);
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
                                      ILoggerFactory loggerFactory,
                                      IHttpContextAccessor accessor)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "bloodType",
                    template: "{controller=BloodType}/{action=Index}/{id?}");

                routes.MapRoute(
                    name:"doctor",
                    template:"{controller=Doctor}/{action=Index}/{id?}");

                //routes.MapRoute(
                //  name: "bloodType",
                //  template: "bloodType/Create",
                //  defaults: new { Controller = "BloodType", action = "Create" });

            });
        }

        private void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
