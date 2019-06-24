using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using Crm.Models.Crm;

namespace Crm.Data
{
    public partial class CrmContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly IHttpContextAccessor httpAccessor;

        public CrmContext(IHttpContextAccessor httpAccessor, DbContextOptions<CrmContext> options):base(options)
        {
            this.httpAccessor = httpAccessor;
        }

        public CrmContext(IHttpContextAccessor httpAccessor)
        {
            this.httpAccessor = httpAccessor;
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Crm.Models.Crm.UserRole>().HasKey(table => new {
              table.UserId, table.RoleId
            });
            builder.Entity<Crm.Models.Crm.Account>()
                  .HasOne(i => i.Address)
                  .WithMany(i => i.Accounts)
                  .HasForeignKey(i => i.AddressId)
                  .HasPrincipalKey(i => i.Id);
            builder.Entity<Crm.Models.Crm.Account>()
                  .HasOne(i => i.Account2)
                  .WithMany(i => i.Accounts2)
                  .HasForeignKey(i => i.ParentAccountId)
                  .HasPrincipalKey(i => i.Id);
            builder.Entity<Crm.Models.Crm.Account>()
                  .HasOne(i => i.Account1)
                  .WithMany(i => i.Accounts1)
                  .HasForeignKey(i => i.BillingAccountId)
                  .HasPrincipalKey(i => i.Id);
            builder.Entity<Crm.Models.Crm.Account>()
                  .HasOne(i => i.AccountRelationType)
                  .WithMany(i => i.Accounts)
                  .HasForeignKey(i => i.RelationTypeId)
                  .HasPrincipalKey(i => i.Id);
            builder.Entity<Crm.Models.Crm.Account>()
                  .HasOne(i => i.Contact)
                  .WithMany(i => i.Accounts)
                  .HasForeignKey(i => i.PrimaryContactId)
                  .HasPrincipalKey(i => i.Id);
            builder.Entity<Crm.Models.Crm.Account>()
                  .HasOne(i => i.User)
                  .WithMany(i => i.Accounts)
                  .HasForeignKey(i => i.CreatedById)
                  .HasPrincipalKey(i => i.Id);
            builder.Entity<Crm.Models.Crm.Account>()
                  .HasOne(i => i.User1)
                  .WithMany(i => i.Accounts1)
                  .HasForeignKey(i => i.ModifiedById)
                  .HasPrincipalKey(i => i.Id);
            builder.Entity<Crm.Models.Crm.Address>()
                  .HasOne(i => i.Country)
                  .WithMany(i => i.Addresses)
                  .HasForeignKey(i => i.CountryId)
                  .HasPrincipalKey(i => i.Id);
            builder.Entity<Crm.Models.Crm.Contact>()
                  .HasOne(i => i.Account)
                  .WithMany(i => i.Contacts)
                  .HasForeignKey(i => i.AccountId)
                  .HasPrincipalKey(i => i.Id);
            builder.Entity<Crm.Models.Crm.UserRole>()
                  .HasOne(i => i.User)
                  .WithMany(i => i.UserRoles)
                  .HasForeignKey(i => i.UserId)
                  .HasPrincipalKey(i => i.Id);
            builder.Entity<Crm.Models.Crm.UserRole>()
                  .HasOne(i => i.Role)
                  .WithMany(i => i.UserRoles)
                  .HasForeignKey(i => i.RoleId)
                  .HasPrincipalKey(i => i.Id);

            this.OnModelBuilding(builder);
        }


        public DbSet<Crm.Models.Crm.Account> Accounts
        {
          get;
          set;
        }

        public DbSet<Crm.Models.Crm.AccountRelationType> AccountRelationTypes
        {
          get;
          set;
        }

        public DbSet<Crm.Models.Crm.Address> Addresses
        {
          get;
          set;
        }

        public DbSet<Crm.Models.Crm.Contact> Contacts
        {
          get;
          set;
        }

        public DbSet<Crm.Models.Crm.Country> Countries
        {
          get;
          set;
        }

        public DbSet<Crm.Models.Crm.Role> Roles
        {
          get;
          set;
        }

        public DbSet<Crm.Models.Crm.User> Users
        {
          get;
          set;
        }

        public DbSet<Crm.Models.Crm.UserRole> UserRoles
        {
          get;
          set;
        }
    }
}
