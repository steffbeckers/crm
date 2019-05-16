using CRM.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.DAL
{
    public class IdentityContext : IdentityDbContext<User>
    {
        public IdentityContext()
        { }

        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("CRM_MSSQL_DB"));
            }
        }

        protected override async void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // Seeding database

            // Roles
            mb.Entity<IdentityRole>().HasData(
                // TODO: Super user?
                //new IdentityRole()
                //{
                //    Id = Guid.Parse("F9AED5CE-087C-4678-8656-D52F8214958D").ToString(),
                //    Name = "SuperAdmin",
                //    NormalizedName = "SUPERADMIN"
                //},
                new IdentityRole()
                {
                    Id = Guid.Parse("179B9251-DB56-47C9-8E6E-5F0E63F1FD18").ToString(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole()
                {
                    Id = Guid.Parse("E230E14D-E8C6-46E8-8DD1-B4962DFE8FA1").ToString(),
                    Name = "User",
                    NormalizedName = "USER"
                }                
            );
        }
    }
}
