using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRM.API.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CRM.API.DAL
{
    public class CRMContext : DbContext
    {
        public CRMContext()
        {}

        public CRMContext (DbContextOptions<CRMContext> options) : base(options)
        {}

        public DbSet<Account> Accounts { get; set; }

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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Account>()
                .HasOne(a => a.PrimaryContact)
                .WithOne()
                .HasForeignKey<Account>(a => a.PrimaryContactId);

            mb.Entity<Account>()
                .HasMany(a => a.Contacts)
                .WithOne(c => c.Account)
                .HasForeignKey(c => c.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            mb.Entity<Account>()
                .HasOne(a => a.BillingAccount)
                .WithOne()
                .HasForeignKey<Account>(a => a.BillingAccountId);

            mb.Entity<Account>()
                .HasOne(a => a.ParentAccount)
                .WithOne()
                .HasForeignKey<Account>(a => a.ParentAccountId);

            // Seeding database

            mb.Entity<RelationType>().HasData(
                new RelationType()
                {
                    Id = Guid.NewGuid(),
                    Name = "customer",
                    DisplayName = "Customer",
                },
                new RelationType()
                {
                    Id = Guid.NewGuid(),
                    Name = "partner",
                    DisplayName = "Partner",
                }
            );
        }
    }
}
