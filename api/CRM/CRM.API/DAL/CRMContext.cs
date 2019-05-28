using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRM.API.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CRM.API.DAL
{
    public class CRMContext : IdentityDbContext<User>
    {
        public CRMContext()
        {}

        public CRMContext (DbContextOptions<CRMContext> options) : base(options)
        {}

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }

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
            base.OnModelCreating(mb);

            // Identity

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

            // Accounts

            // Soft delete query filter
            mb.Entity<Account>().HasQueryFilter(m => EF.Property<DateTime>(m, "DeletedOn") == null);

            // Primary contact
            mb.Entity<Account>()
                .HasOne(a => a.PrimaryContact)
                .WithOne()
                .HasForeignKey<Account>(a => a.PrimaryContactId);

            // Billing account
            mb.Entity<Account>()
                .HasOne(a => a.BillingAccount)
                .WithOne()
                .HasForeignKey<Account>(a => a.BillingAccountId);

            // Parent account
            mb.Entity<Account>()
                .HasOne(a => a.ParentAccount)
                .WithOne()
                .HasForeignKey<Account>(a => a.ParentAccountId);

            // Account Contacts relation
            mb.Entity<Account>()
                .HasMany(a => a.Contacts)
                .WithOne(c => c.Account)
                .HasForeignKey(c => c.AccountId)
                .OnDelete(DeleteBehavior.SetNull);

            // CreatedBy
            mb.Entity<Account>()
                .HasOne(a => a.CreatedBy)
                .WithOne()
                .HasForeignKey<Account>(a => a.CreatedById);

            // Countries
            //mb.Entity<Country>()
            //    .Property<string>("CallingCodes")
            //    .HasField("callingCodes");

            // Seeding database

            // Account Relation Types
            mb.Entity<AccountRelationType>().HasData(
                new AccountRelationType()
                {
                    Id = Guid.Parse("0E8BA1B4-0382-4A39-BB0D-2F654A1F1ABC"),
                    Name = "customer",
                    DisplayName = "Customer",
                },
                new AccountRelationType()
                {
                    Id = Guid.Parse("5E88157A-3EC0-4C04-9B86-041A07446F12"),
                    Name = "partner",
                    DisplayName = "Partner",
                }
            );

            // Countries
            //List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(File.ReadAllText(Directory.GetCurrentDirectory() + "/Data/Countries.json"));
            //for (int i = 0; i < countries.Count; i++)
            //{
            //    if (countries[i].Id == Guid.Empty)
            //    {
            //        countries[i].Id = Guid.NewGuid();
            //    }
            //}
            //mb.Entity<Country>().HasData(countries);
        }

        // Overrides for soft delete
        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                // Define per entity what needs to happen on soft delete
                if (entry.Entity.GetType().Name == "Account")
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.CurrentValues["DeletedOn"] = null;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entry.CurrentValues["DeletedOn"] = DateTime.Now;
                            break;
                    }
                }
            }
        }
    }
}
