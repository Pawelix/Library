using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using Pawel.Cms.Domain.Services.Implementation;
using System.IO;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;
using Pawel.Cms.Domain.Context;

namespace Pawel.Cms.Api
{
    public class Startup
    {
        private readonly Container container;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            container = new Container();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSimpleInjector(container, options =>
            {
                options.AddAspNetCore()
                .AddControllerActivation()
                .AddViewComponentActivation()
                .AddPageModelActivation()
                .AddTagHelperActivation();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Swagger Sample",
                    Version = "v1",                 
                });                
                var xmlFile = Path.ChangeExtension(typeof(Startup).Assembly.Location, ".xml");
                c.IncludeXmlComments(xmlFile);
            });

            services.AddDbContext<CmsDBContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
         
            app.UseSimpleInjector(container, options =>
            {            
                options.UseLogging();            
            });

            InitializeContainer();

            // Always verify the container
            container.Verify();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {      
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1");
            });
            app.UseMvc();
        }


        private void InitializeContainer()
        {
            var domainAssembly = typeof(BooksService).Assembly;

            var registrations =
                from type in domainAssembly.GetExportedTypes()
                where type.Namespace.StartsWith("Pawel.Cms.Domain") && !type.Namespace.Equals("Pawel.Cms.Domain.Context")
                from service in type.GetInterfaces()
                select new { service, implementation = type };

            foreach (var reg in registrations)
            {
                container.Register(reg.service, reg.implementation, Lifestyle.Transient);
            }
    
            container.Verify();
        }
    }
}



