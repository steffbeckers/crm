﻿using AutoMapper;
using CRM.API.DAL;
using CRM.API.Models;
using CRM.API.Services;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.Edm;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;
using System.Threading.Tasks;

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

            // Authentication
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CRM_MSSQL_DB")));

            services.AddIdentity<User, IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Sign in
                options.SignIn.RequireConfirmedEmail = false;

                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 10;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            // JWT's
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Authentication").GetValue<string>("Secret"));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // Authorization
            services.AddAuthorization(options =>
            {
                // Policies
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
            });

            // Connection to the CRM database
            services.AddDbContext<CRMContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CRM_MSSQL_DB")));

            // OData
            services.AddOData();
            services.AddODataQueryFilter();

            // AutoMapper
            services.AddAutoMapper();

            // Services
            // - Sending emails
            services.AddTransient<IEmailSender, EmailSender>();

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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    });
                });

                app.UseHsts();
            }

            // CORS
            app.UseCors(options => {
                options.WithOrigins(Configuration.GetValue<string>("AllowedHosts"))
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });

            // Authentication
            app.UseAuthentication();

            // MVC
            app.UseMvc(options =>
            {
                // OData
                options.MapODataServiceRoute("odata", "odata", GetEdmModel(app.ApplicationServices));
                options.Count().Filter().OrderBy().Expand().Select().MaxTop(200);
                options.EnableDependencyInjection();
            });

            // Authorization
            CreateRolesAndAdminUser(serviceProvider);
        }

        private static IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder(serviceProvider);

            builder.EntitySet<Account>("accounts");
            builder.EntitySet<Contact>("contacts");

            return builder.GetEdmModel();
        }

        private void CreateRolesAndAdminUser(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            // Roles

            Task<IdentityRole> adminRole = roleManager.FindByNameAsync("Admin");
            adminRole.Wait();
            if (adminRole.Result == null)
            {
                IdentityRole newAdminRole = new IdentityRole()
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                };

                var createAdminRole = roleManager.CreateAsync(newAdminRole);
                createAdminRole.Wait();
            }

            Task<IdentityRole> userRole = roleManager.FindByNameAsync("User");
            userRole.Wait();
            if (userRole.Result == null)
            {
                IdentityRole newUserRole = new IdentityRole()
                {
                    Name = "User",
                    NormalizedName = "USER"
                };

                var createUserRole = roleManager.CreateAsync(newUserRole);
                createUserRole.Wait();
            }

            // Check if the Admin user exists and create it if not
            // Add to the Admin role

            Task<User> adminUser = userManager.FindByNameAsync(Configuration.GetSection("Admin").GetValue<string>("Username"));
            adminUser.Wait();
            if (adminUser.Result == null)
            {
                User newAdminUser = new User() {
                    Email = Configuration.GetSection("Admin").GetValue<string>("Email"),
                    UserName = Configuration.GetSection("Admin").GetValue<string>("Username"),
                    FirstName = Configuration.GetSection("Admin").GetValue<string>("FirstName"),
                    LastName = Configuration.GetSection("Admin").GetValue<string>("LastName"),
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };

                Task<IdentityResult> newUser = userManager.CreateAsync(newAdminUser, Configuration.GetSection("Admin").GetValue<string>("Password"));
                newUser.Wait();
                if (newUser.Result.Succeeded)
                {
                    Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(newAdminUser, "Admin");
                    newUserRole.Wait();
                }
            }

        }
    }
}
