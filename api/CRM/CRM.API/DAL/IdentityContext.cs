﻿using CRM.API.Models;
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

            mb.Entity<User>(e => e.ToTable("Users"));
            mb.Entity<IdentityRole>(e => e.ToTable("Roles"));
            mb.Entity<IdentityUserRole<string>>(e =>
            {
                e.ToTable("UserRoles");
                // In case you changed the TKey type
                // e.HasKey(key => new { key.UserId, key.RoleId });
            });
            mb.Entity<IdentityUserClaim<string>>(e => e.ToTable("UserClaims"));
            mb.Entity<IdentityUserLogin<string>>(e =>
            {
                e.ToTable("UserLogins");
                // In case you changed the TKey type
                //e.HasKey(key => new { key.ProviderKey, key.LoginProvider });       
            });
            mb.Entity<IdentityRoleClaim<string>>(e => e.ToTable("RoleClaims"));
            mb.Entity<IdentityUserToken<string>>(e =>
            {
                e.ToTable("UserTokens");
                // In case you changed the TKey type
                //e.HasKey(key => new { key.UserId, key.LoginProvider, key.Name });
            });
        }
    }
}
