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

            modelBuilder.Entity("Azox.XQR.Business.Domain.Catalog.Category", b =>
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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(4);

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit")
                        .HasColumnOrder(6);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(2);

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<Guid?>("PictureId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("Name");

                    b.HasIndex("ParentId");

                    b.HasIndex("PictureId");

                    b.ToTable("Category", "Catalog");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Catalog.Product", b =>
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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(4);

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit")
                        .HasColumnOrder(6);

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

            modelBuilder.Entity("Azox.XQR.Business.Domain.Management.License", b =>
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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(2);

                    b.Property<string>("LicenseData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(5);

                    b.Property<string>("LicenseKey")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(4);

                    b.Property<int>("MerchantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("MerchantId");

                    b.ToTable("License", "Management");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Management.Location", b =>
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

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("Name");

                    b.HasIndex("ServiceId");

                    b.ToTable("Location", "Management");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Management.MenuItem", b =>
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
                        .HasColumnOrder(8);

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(7);

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

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(6);

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("Name");

                    b.HasIndex("ParentId");

                    b.ToTable("MenuItem", "Management");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Management.MenuItemRight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit")
                        .HasColumnOrder(2);

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("UserGroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("UserGroupId");

                    b.ToTable("MenuItemRight", "Management");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Management.Merchant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(7);

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

                    b.Property<int>("MerchantType")
                        .HasColumnType("int")
                        .HasColumnOrder(6);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(2);

                    b.Property<Guid?>("PictureId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CreationTime");

                    b.HasIndex("Name");

                    b.HasIndex("PictureId");

                    b.ToTable("Merchant", "Management");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Management.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Contacts")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(7);

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

                    b.Property<int>("MerchantId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(2);

                    b.Property<int>("ServiceType")
                        .HasColumnType("int")
                        .HasColumnOrder(6);

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("MerchantId");

                    b.HasIndex("Name");

                    b.ToTable("Service", "Management");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Management.User", b =>
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

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnOrder(7);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(2);

                    b.Property<bool>("IsLocked")
                        .HasColumnType("bit")
                        .HasColumnOrder(8);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(6);

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(5);

                    b.Property<int>("UserGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("UserGroupId");

                    b.ToTable("User", "Management");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Management.UserGroup", b =>
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

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit")
                        .HasColumnOrder(6);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(4);

                    b.Property<int?>("MerchantId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("MerchantId");

                    b.HasIndex("Name");

                    b.ToTable("UserGroup", "Management");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Media.Picture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(3);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.ToTable("Picture", "Media");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Media.ProductPicture", b =>
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

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int")
                        .HasColumnOrder(5);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(2);

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit")
                        .HasColumnOrder(4);

                    b.Property<Guid>("PictureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("PictureId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPicture", "Media");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Order.Order", b =>
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

                    b.Property<int>("MerchantId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("MerchantId");

                    b.ToTable("Order", "Finance");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Order.OrderItem", b =>
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

                    b.Property<string>("Note")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnOrder(4);

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem", "Finance");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Region.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AddressLine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(2);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float")
                        .HasColumnOrder(3);

                    b.Property<double?>("Longitude")
                        .HasColumnType("float")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CreationTime");

                    b.HasIndex("DistrictId");

                    b.ToTable("Address", "Region");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Region.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(6);

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

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("Name");

                    b.ToTable("City", "Region");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Region.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnOrder(6);

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

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CreationTime");

                    b.HasIndex("Name");

                    b.ToTable("District", "Region");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Catalog.Category", b =>
                {
                    b.HasOne("Azox.XQR.Business.Domain.Catalog.Category", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Azox.XQR.Business.Domain.Media.Picture", "Picture")
                        .WithMany()
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Parent");

                    b.Navigation("Picture");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Catalog.Product", b =>
                {
                    b.HasOne("Azox.XQR.Business.Domain.Catalog.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Management.License", b =>
                {
                    b.HasOne("Azox.XQR.Business.Domain.Management.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Merchant");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Management.Location", b =>
                {
                    b.HasOne("Azox.XQR.Business.Domain.Management.Service", "Service")
                        .WithMany("Locations")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Management.MenuItem", b =>
                {
                    b.HasOne("Azox.XQR.Business.Domain.Management.MenuItem", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Management.MenuItemRight", b =>
                {
                    b.HasOne("Azox.XQR.Business.Domain.Management.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Azox.XQR.Business.Domain.Management.UserGroup", "UserGroup")
                        .WithMany()
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Management.Merchant", b =>
                {
                    b.HasOne("Azox.XQR.Business.Domain.Region.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Azox.XQR.Business.Domain.Media.Picture", "Picture")
                        .WithMany()
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Address");

                    b.Navigation("Picture");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Management.Service", b =>
                {
                    b.HasOne("Azox.XQR.Business.Domain.Management.Merchant", "Merchant")
                        .WithMany("Services")
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Merchant");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Management.User", b =>
                {
                    b.HasOne("Azox.XQR.Business.Domain.Management.UserGroup", "UserGroup")
                        .WithMany("Users")
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Management.UserGroup", b =>
                {
                    b.HasOne("Azox.XQR.Business.Domain.Management.Merchant", "Merchant")
                        .WithMany("UserGroups")
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Merchant");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Media.ProductPicture", b =>
                {
                    b.HasOne("Azox.XQR.Business.Domain.Media.Picture", "Picture")
                        .WithMany()
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Azox.XQR.Business.Domain.Catalog.Product", "Product")
                        .WithMany("Pictures")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Picture");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Order.Order", b =>
                {
                    b.HasOne("Azox.XQR.Business.Domain.Management.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Merchant");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Order.OrderItem", b =>
                {
                    b.HasOne("Azox.XQR.Business.Domain.Order.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Azox.XQR.Business.Domain.Catalog.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Region.Address", b =>
                {
                    b.HasOne("Azox.XQR.Business.Domain.Region.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Azox.XQR.Business.Domain.Region.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("District");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Region.District", b =>
                {
                    b.HasOne("Azox.XQR.Business.Domain.Region.City", "City")
                        .WithMany("Districts")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Catalog.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Catalog.Product", b =>
                {
                    b.Navigation("Pictures");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Management.Merchant", b =>
                {
                    b.Navigation("Services");

                    b.Navigation("UserGroups");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Management.Service", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Management.UserGroup", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Order.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Azox.XQR.Business.Domain.Region.City", b =>
                {
                    b.Navigation("Districts");
                });
#pragma warning restore 612, 618
        }
    }
}
