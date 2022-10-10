﻿// <auto-generated />
using System;
using Azox.XQR.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Azox.XQR.Persistence.Migrations
{
    [DbContext(typeof(XQRDbContext))]
    partial class XQRDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Azox.Business.Core.Domain.InstallationStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Error")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastExecutionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("StepName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Success")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("InstallationStep");
                });

            modelBuilder.Entity("Azox.XQR.Business.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(5);

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnOrder(3);

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int")
                        .HasColumnOrder(7);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnOrder(6);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(4);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(2);

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("Name");

                    b.HasIndex("ParentId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Category", "Catalog");
                });

            modelBuilder.Entity("Azox.XQR.Business.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(5);

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnOrder(3);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(4);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(2);

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("Name");

                    b.HasIndex("ServiceId");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Location", "Management");
                });

            modelBuilder.Entity("Azox.XQR.Business.Merchant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(8);

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(9);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(5);

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnOrder(3);

                    b.Property<string>("FacebookLink")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(11);

                    b.Property<string>("InstagramLink")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(12);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnOrder(7);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(4);

                    b.Property<int>("MerchantType")
                        .HasColumnType("int")
                        .HasColumnOrder(6);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(2);

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(10);

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("Name");

                    b.ToTable("Merchant", "Management");
                });

            modelBuilder.Entity("Azox.XQR.Business.MerchantServe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Contacts")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(8);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(5);

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnOrder(3);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnOrder(6);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(4);

                    b.Property<int>("MerchantId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(2);

                    b.Property<int>("ServiceType")
                        .HasColumnType("int")
                        .HasColumnOrder(7);

                    b.Property<string>("ThemeTypeName")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(10);

                    b.Property<string>("WorkingHours")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(9);

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("MerchantId");

                    b.HasIndex("Name");

                    b.ToTable("MerchantServe", "Management");
                });

            modelBuilder.Entity("Azox.XQR.Business.MerchantServeUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("ServiceId");

                    b.HasIndex("UserId");

                    b.ToTable("MerchantServeUser", "Auth");
                });

            modelBuilder.Entity("Azox.XQR.Business.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(3);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(2);

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("LocationId");

                    b.ToTable("Order", "Finance");
                });

            modelBuilder.Entity("Azox.XQR.Business.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(3);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(2);

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("UnitPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem", "Finance");
                });

            modelBuilder.Entity("Azox.XQR.Business.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(5);

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnOrder(3);

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int")
                        .HasColumnOrder(7);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnOrder(6);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(4);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(2);

                    b.Property<string>("OldPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(9);

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(8);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreationTime");

                    b.HasIndex("Name");

                    b.ToTable("Product", "Catalog");
                });

            modelBuilder.Entity("Azox.XQR.Business.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(3);

                    b.Property<string>("FirstName")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(4);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnOrder(9);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(2);

                    b.Property<bool>("IsLocked")
                        .HasColumnType("bit")
                        .HasColumnOrder(10);

                    b.Property<DateTime?>("LastLoginTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(12);

                    b.Property<string>("LastName")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(5);

                    b.Property<bool>("PasswordChangeOnFirstLogin")
                        .HasColumnType("bit")
                        .HasColumnOrder(11);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(8);

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(7);

                    b.Property<int>("UserGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(6);

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("UserGroupId");

                    b.ToTable("User", "Auth");
                });

            modelBuilder.Entity("Azox.XQR.Business.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(5);

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnOrder(3);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(4);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(2);

                    b.Property<int>("UserGroupType")
                        .HasColumnType("int")
                        .HasColumnOrder(6);

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("Name");

                    b.ToTable("UserGroup", "Auth");
                });

            modelBuilder.Entity("Azox.XQR.Business.Category", b =>
                {
                    b.HasOne("Azox.XQR.Business.Category", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Azox.XQR.Business.MerchantServe", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Azox.XQR.Business.Location", b =>
                {
                    b.HasOne("Azox.XQR.Business.MerchantServe", "Service")
                        .WithMany("Locations")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Azox.XQR.Business.MerchantServe", b =>
                {
                    b.HasOne("Azox.XQR.Business.Merchant", "Merchant")
                        .WithMany("Services")
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Merchant");
                });

            modelBuilder.Entity("Azox.XQR.Business.MerchantServeUser", b =>
                {
                    b.HasOne("Azox.XQR.Business.MerchantServe", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Azox.XQR.Business.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Azox.XQR.Business.Order", b =>
                {
                    b.HasOne("Azox.XQR.Business.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Azox.XQR.Business.OrderItem", b =>
                {
                    b.HasOne("Azox.XQR.Business.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Azox.XQR.Business.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Azox.XQR.Business.Product", b =>
                {
                    b.HasOne("Azox.XQR.Business.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Azox.XQR.Business.User", b =>
                {
                    b.HasOne("Azox.XQR.Business.UserGroup", "UserGroup")
                        .WithMany()
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("Azox.XQR.Business.Merchant", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("Azox.XQR.Business.MerchantServe", b =>
                {
                    b.Navigation("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}
