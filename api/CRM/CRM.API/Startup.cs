using AutoMapper;
using CRM.API.DAL;
using CRM.API.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace CRM.API
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
            // CORS
            services.AddCors();

            // Connection to database
            services.AddDbContext<CRMContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CRM_MSSQL_DB")));

            // OData
            services.AddOData();
            services.AddODataQueryFilter();

            // AutoMapper
            services.AddAutoMapper();

            // MVC
            services.AddMvc(options => {
                // OData
                // TODO: Remove when OData does not causes exceptions anymore
                options.EnableEndpointRouting = false;
            })
                // .NET Core version
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                // JSON settings
                .AddJsonOptions(options => {
                    //options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    //options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

                    // camelCase
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                    // PascalCase
                    //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });
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
                //app.UseExceptionHandler(appBuilder =>
                //{
                //    appBuilder.Run(async context =>
                //    {
                //        context.Response.StatusCode = 500;
                //        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                //    });
                //});
            }

            // CORS
            app.UseCors(options => {
                options.WithOrigins(Configuration.GetValue<string>("AllowedHosts"))
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });

            app.UseMvc(options =>
            {
                // OData
                options.MapODataServiceRoute("odata", "odata", GetEdmModel(app.ApplicationServices));
                options.Count().Filter().OrderBy().Expand().Select().MaxTop(200);
                options.EnableDependencyInjection();
            });
        }

        private static IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder(serviceProvider);

            builder.EntitySet<Account>("accounts");
            builder.EntitySet<Contact>("contacts");

            return builder.GetEdmModel();
        }
    }
}
