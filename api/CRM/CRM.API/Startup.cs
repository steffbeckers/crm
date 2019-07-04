using AutoMapper;
using CRM.API.CodeGenerator;
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
using Microsoft.OData.Edm.Csdl;
using Microsoft.OData.Edm.Vocabularies;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            // Connection to the CRM database
            services.AddDbContext<CRMContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CRM_MSSQL_DB")));

            // Authentication
            services.AddIdentity<User, IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddEntityFrameworkStores<CRMContext>()
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
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,
                    ValidateLifetime = true
                };
            });

            // Authorization
            services.AddAuthorization(options =>
            {
                // Policies
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
            });

            // OData
            services.AddOData();
            services.AddODataQueryFilter();

            // AutoMapper
            services.AddAutoMapper();

            // Services
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddSingleton<IEmailSender, EmailSender>();

            // Use HttpContext from custom components
            services.AddHttpContextAccessor();

            // MVC
            services.AddMvc(options =>
            {
                // OData
                // TODO: Remove when OData does not causes exceptions anymore
                options.EnableEndpointRouting = false;
            })
                // .NET Core version
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                // JSON settings
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
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

            // Update database migrations on startup
            UpdateDatabase(app);

            // CORS
            app.UseCors(options =>
            {
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
                IEdmModel odataModel = GetEdmModel(app.ApplicationServices);

                // Code generator
                ConfigureODataMetadataForCodeGenerator(odataModel);

                // OData
                options.MapODataServiceRoute("odata", "api/odata", odataModel);
                options.Count().Filter().OrderBy().Expand().Select().MaxTop(200);
                options.EnableDependencyInjection();
            });

            // Authorization
            CreateRolesAndAdminUser(serviceProvider);
        }

        private static IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder(serviceProvider);
            builder.EnableLowerCamelCase();

            builder.EntitySet<Account>("Accounts");

            var users = builder.EntitySet<User>("Users");
            users.EntityType.Ignore(u => u.ConcurrencyStamp);
            users.EntityType.Ignore(u => u.NormalizedEmail);
            users.EntityType.Ignore(u => u.NormalizedUserName);
            users.EntityType.Ignore(u => u.PasswordHash);
            users.EntityType.Ignore(u => u.SecurityStamp);

            return builder.GetEdmModel();
        }

        private void ConfigureODataMetadataForCodeGenerator(IEdmModel model)
        {
            // Namespace
            string codeGenNamespace = "http://code.gen/schema";
            model.SetNamespacePrefixMappings(new Dictionary<string, string> { { "codegen", codeGenNamespace } });

            foreach (IEdmEntityType entityType in model.SchemaElementsAcrossModels().OfType<IEdmEntityType>())
            {
                // Use reflection to retrieve models with attributes
                Type type = Type.GetType(entityType.FullName() + ", CRM.API"); // TODO: Make assembly name dynamic
                if (type == null) { continue; }

                // For custom attributes on the model itself
                object[] entityAttrs = type.GetCustomAttributes(true);
                foreach (object attr in entityAttrs)
                {
                    CodeGenEntityPluralizedAttribute entityPluralizedAttr = attr as CodeGenEntityPluralizedAttribute;
                    if (entityPluralizedAttr != null)
                    {
                        model.SetAnnotationValue(
                            entityType,
                            codeGenNamespace,
                            "Pluralized",
                            new EdmStringConstant(EdmCoreModel.Instance.GetString(true), entityPluralizedAttr.Value)
                        );
                    }
                }

                PropertyInfo[] props = type.GetProperties();
                foreach (PropertyInfo prop in props)
                {
                    object[] propAttrs = prop.GetCustomAttributes(true);
                    foreach (object attr in propAttrs)
                    {
                        CodeGenInputTypeAttribute inputTypeAttr = attr as CodeGenInputTypeAttribute;
                        if (inputTypeAttr != null)
                        {
                            foreach (IEdmProperty entityTypeProperty in entityType.Properties())
                            {
                                if (entityTypeProperty.Name.Equals(prop.Name, StringComparison.OrdinalIgnoreCase))
                                {
                                    model.SetAnnotationValue(
                                        entityTypeProperty,
                                        codeGenNamespace,
                                        "InputType",
                                        new EdmStringConstant(EdmCoreModel.Instance.GetString(true), inputTypeAttr.Value)
                                    );
                                }
                            }
                        }

                        CodeGenFieldHiddenAttribute fieldHiddenAttr = attr as CodeGenFieldHiddenAttribute;
                        if (fieldHiddenAttr != null)
                        {
                            foreach (IEdmProperty entityTypeProperty in entityType.Properties())
                            {
                                if (entityTypeProperty.Name.Equals(prop.Name, StringComparison.OrdinalIgnoreCase))
                                {
                                    model.SetAnnotationValue(
                                        entityTypeProperty,
                                        codeGenNamespace,
                                        "Hidden",
                                        new EdmStringConstant(EdmCoreModel.Instance.GetString(true), fieldHiddenAttr.Value ? "true" : "false")
                                    );
                                }
                            }
                        }

                        CodeGenFieldDisplayNameAttribute fieldDisplayNameAttr = attr as CodeGenFieldDisplayNameAttribute;
                        if (fieldDisplayNameAttr != null)
                        {
                            foreach (IEdmProperty entityTypeProperty in entityType.Properties())
                            {
                                if (entityTypeProperty.Name.Equals(prop.Name, StringComparison.OrdinalIgnoreCase))
                                {
                                    model.SetAnnotationValue(
                                        entityTypeProperty,
                                        codeGenNamespace,
                                        "DisplayName",
                                        new EdmStringConstant(EdmCoreModel.Instance.GetString(true), fieldDisplayNameAttr.Value)
                                    );
                                }
                            }
                        }

                        CodeGenFieldSortAttribute fieldSortAttr = attr as CodeGenFieldSortAttribute;
                        if (fieldSortAttr != null)
                        {
                            foreach (IEdmProperty entityTypeProperty in entityType.Properties())
                            {
                                if (entityTypeProperty.Name.Equals(prop.Name, StringComparison.OrdinalIgnoreCase))
                                {
                                    model.SetAnnotationValue(
                                        entityTypeProperty,
                                        codeGenNamespace,
                                        "Sort",
                                        new EdmStringConstant(EdmCoreModel.Instance.GetString(true), fieldSortAttr.Value.ToString())
                                    );
                                }
                            }
                        }

                        CodeGenLookupIdAttribute lookupIdAttr = attr as CodeGenLookupIdAttribute;
                        if (lookupIdAttr != null)
                        {
                            foreach (IEdmProperty entityTypeProperty in entityType.Properties())
                            {
                                if (entityTypeProperty.Name.Equals(prop.Name, StringComparison.OrdinalIgnoreCase))
                                {
                                    model.SetAnnotationValue(
                                        entityTypeProperty,
                                        codeGenNamespace,
                                        "LookupId",
                                        new EdmStringConstant(EdmCoreModel.Instance.GetString(true), lookupIdAttr.Value)
                                    );
                                }
                            }
                        }

                        CodeGenLookupFieldToDisplayAttribute lookupFieldToDisplayAttr = attr as CodeGenLookupFieldToDisplayAttribute;
                        if (lookupFieldToDisplayAttr != null)
                        {
                            foreach (IEdmProperty entityTypeProperty in entityType.Properties())
                            {
                                if (entityTypeProperty.Name.Equals(prop.Name, StringComparison.OrdinalIgnoreCase))
                                {
                                    model.SetAnnotationValue(
                                        entityTypeProperty,
                                        codeGenNamespace,
                                        "LookupFieldToDisplay",
                                        new EdmStringConstant(EdmCoreModel.Instance.GetString(true), lookupFieldToDisplayAttr.Value ? "true" : "false")
                                    );
                                }
                            }
                        }

                        CodeGenRelationSortAttribute relationSortAttr = attr as CodeGenRelationSortAttribute;
                        if (relationSortAttr != null)
                        {
                            foreach (IEdmProperty entityTypeProperty in entityType.Properties())
                            {
                                if (entityTypeProperty.Name.Equals(prop.Name, StringComparison.OrdinalIgnoreCase))
                                {
                                    model.SetAnnotationValue(
                                        entityTypeProperty,
                                        codeGenNamespace,
                                        "Sort",
                                        new EdmStringConstant(EdmCoreModel.Instance.GetString(true), relationSortAttr.Value.ToString())
                                    );
                                }
                            }
                        }
                    }
                }

                // TEST Logging in console
                //Console.WriteLine(entityType.FullName());
                //foreach (IEdmProperty property in entityType.Properties())
                //{
                //    Console.WriteLine(" " + property.Name);
                //}
                //Console.WriteLine();
            }
        }

        private void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<CRMContext>())
                {
                    context.Database.Migrate();
                }
            }
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

            Task<IdentityRole> salesRole = roleManager.FindByNameAsync("Sales");
            salesRole.Wait();
            if (salesRole.Result == null)
            {
                IdentityRole newSalesRole = new IdentityRole()
                {
                    Name = "Sales",
                    NormalizedName = "SALES"
                };

                var createSalesRole = roleManager.CreateAsync(newSalesRole);
                createSalesRole.Wait();
            }

            Task<IdentityRole> hrRole = roleManager.FindByNameAsync("HR");
            hrRole.Wait();
            if (hrRole.Result == null)
            {
                IdentityRole newHrRole = new IdentityRole()
                {
                    Name = "HR",
                    NormalizedName = "HR"
                };

                var createHrRole = roleManager.CreateAsync(newHrRole);
                createHrRole.Wait();
            }

            // Check if the Admin user exists and create it if not
            // Add to the Admin role

            Task<User> adminUser = userManager.FindByNameAsync(Configuration.GetSection("Admin").GetValue<string>("Username"));
            adminUser.Wait();
            if (adminUser.Result == null)
            {
                User newAdminUser = new User()
                {
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
