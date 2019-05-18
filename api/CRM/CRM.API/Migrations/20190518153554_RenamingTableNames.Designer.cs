﻿// <auto-generated />
using System;
using CRM.API.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRM.API.Migrations
{
    [DbContext(typeof(CRMContext))]
    [Migration("20190518153554_RenamingTableNames")]
    partial class RenamingTableNames
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRM.API.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AddressId");

                    b.Property<Guid?>("BillingAccountId");

                    b.Property<Guid>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("Description");

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<string>("Fax")
                        .HasMaxLength(50);

                    b.Property<Guid>("ModifiedById");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid?>("ParentAccountId");

                    b.Property<Guid?>("PrimaryContactId");

                    b.Property<Guid?>("RelationTypeId");

                    b.Property<string>("Telephone")
                        .HasMaxLength(50);

                    b.Property<string>("VATNumber")
                        .HasMaxLength(50);

                    b.Property<string>("Website")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("BillingAccountId")
                        .IsUnique()
                        .HasFilter("[BillingAccountId] IS NOT NULL");

                    b.HasIndex("ParentAccountId")
                        .IsUnique()
                        .HasFilter("[ParentAccountId] IS NOT NULL");

                    b.HasIndex("PrimaryContactId")
                        .IsUnique()
                        .HasFilter("[PrimaryContactId] IS NOT NULL");

                    b.HasIndex("RelationTypeId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("CRM.API.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .HasMaxLength(80);

                    b.Property<Guid?>("CountryId");

                    b.Property<Guid>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<decimal?>("Latitude")
                        .HasColumnType("decimal(9, 6)");

                    b.Property<decimal?>("Longitude")
                        .HasColumnType("decimal(9, 6)");

                    b.Property<Guid>("ModifiedById");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Number")
                        .HasMaxLength(50);

                    b.Property<string>("PostalCode")
                        .HasMaxLength(50);

                    b.Property<string>("State")
                        .HasMaxLength(50);

                    b.Property<string>("Street")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CRM.API.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AccountId");

                    b.Property<Guid>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<int?>("Gender");

                    b.Property<string>("JobTitle")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("MobilePhone")
                        .HasMaxLength(50);

                    b.Property<Guid>("ModifiedById");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Telephone")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("CRM.API.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("CRM.API.Models.RelationType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("RelationTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0e8ba1b4-0382-4a39-bb0d-2f654a1f1abc"),
                            DisplayName = "Customer",
                            Name = "customer"
                        },
                        new
                        {
                            Id = new Guid("5e88157a-3ec0-4c04-9b86-041a07446f12"),
                            DisplayName = "Partner",
                            Name = "partner"
                        });
                });

            modelBuilder.Entity("CRM.API.Models.Account", b =>
                {
                    b.HasOne("CRM.API.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("CRM.API.Models.Account", "BillingAccount")
                        .WithOne()
                        .HasForeignKey("CRM.API.Models.Account", "BillingAccountId");

                    b.HasOne("CRM.API.Models.Account", "ParentAccount")
                        .WithOne()
                        .HasForeignKey("CRM.API.Models.Account", "ParentAccountId");

                    b.HasOne("CRM.API.Models.Contact", "PrimaryContact")
                        .WithOne()
                        .HasForeignKey("CRM.API.Models.Account", "PrimaryContactId");

                    b.HasOne("CRM.API.Models.RelationType", "RelationType")
                        .WithMany()
                        .HasForeignKey("RelationTypeId");
                });

            modelBuilder.Entity("CRM.API.Models.Address", b =>
                {
                    b.HasOne("CRM.API.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("CRM.API.Models.Contact", b =>
                {
                    b.HasOne("CRM.API.Models.Account", "Account")
                        .WithMany("Contacts")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
