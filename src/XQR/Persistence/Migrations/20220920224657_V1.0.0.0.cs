using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Azox.XQR.Persistence.Migrations
{
    public partial class V1000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Region");

            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.EnsureSchema(
                name: "Management");

            migrationBuilder.EnsureSchema(
                name: "Finance");

            migrationBuilder.EnsureSchema(
                name: "Media");

            migrationBuilder.CreateTable(
                name: "City",
                schema: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                schema: "Management",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItem_MenuItem_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Management",
                        principalTable: "MenuItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                schema: "Media",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "District",
                schema: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "Region",
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    PictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Catalog",
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Category_Picture_PictureId",
                        column: x => x.PictureId,
                        principalSchema: "Media",
                        principalTable: "Picture",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "Region",
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Address_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "Region",
                        principalTable: "District",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Catalog",
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Merchant",
                schema: "Management",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MerchantType = table.Column<int>(type: "int", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    PictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Merchant_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Region",
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Merchant_Picture_PictureId",
                        column: x => x.PictureId,
                        principalSchema: "Media",
                        principalTable: "Picture",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductPicture",
                schema: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPicture_Picture_PictureId",
                        column: x => x.PictureId,
                        principalSchema: "Media",
                        principalTable: "Picture",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductPicture_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "License",
                schema: "Management",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LicenseKey = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    LicenseData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_License", x => x.Id);
                    table.ForeignKey(
                        name: "FK_License_Merchant_MerchantId",
                        column: x => x.MerchantId,
                        principalSchema: "Management",
                        principalTable: "Merchant",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "Finance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    MerchantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Merchant_MerchantId",
                        column: x => x.MerchantId,
                        principalSchema: "Management",
                        principalTable: "Merchant",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Service",
                schema: "Management",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServiceType = table.Column<int>(type: "int", nullable: false),
                    Contacts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_Merchant_MerchantId",
                        column: x => x.MerchantId,
                        principalSchema: "Management",
                        principalTable: "Merchant",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                schema: "Management",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    MerchantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroup_Merchant_MerchantId",
                        column: x => x.MerchantId,
                        principalSchema: "Management",
                        principalTable: "Merchant",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                schema: "Finance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Finance",
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "Management",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalSchema: "Management",
                        principalTable: "Service",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MenuItemRight",
                schema: "Management",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    UserGroupId = table.Column<int>(type: "int", nullable: false),
                    MenuItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemRight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItemRight_MenuItem_MenuItemId",
                        column: x => x.MenuItemId,
                        principalSchema: "Management",
                        principalTable: "MenuItem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MenuItemRight_UserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalSchema: "Management",
                        principalTable: "UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Management",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    UserGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalSchema: "Management",
                        principalTable: "UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                schema: "Region",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CreationTime",
                schema: "Region",
                table: "Address",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_Address_DistrictId",
                schema: "Region",
                table: "Address",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CreationTime",
                schema: "Catalog",
                table: "Category",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_Category_Name",
                schema: "Catalog",
                table: "Category",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                schema: "Catalog",
                table: "Category",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_PictureId",
                schema: "Catalog",
                table: "Category",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CreationTime",
                schema: "Region",
                table: "City",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_City_Name",
                schema: "Region",
                table: "City",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_District_CityId",
                schema: "Region",
                table: "District",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_District_CreationTime",
                schema: "Region",
                table: "District",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_District_Name",
                schema: "Region",
                table: "District",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_License_CreationTime",
                schema: "Management",
                table: "License",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_License_MerchantId",
                schema: "Management",
                table: "License",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_CreationTime",
                schema: "Management",
                table: "Location",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_Location_Name",
                schema: "Management",
                table: "Location",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Location_ServiceId",
                schema: "Management",
                table: "Location",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_CreationTime",
                schema: "Management",
                table: "MenuItem",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_Name",
                schema: "Management",
                table: "MenuItem",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_ParentId",
                schema: "Management",
                table: "MenuItem",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemRight_CreationTime",
                schema: "Management",
                table: "MenuItemRight",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemRight_MenuItemId",
                schema: "Management",
                table: "MenuItemRight",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemRight_UserGroupId",
                schema: "Management",
                table: "MenuItemRight",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Merchant_AddressId",
                schema: "Management",
                table: "Merchant",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Merchant_CreationTime",
                schema: "Management",
                table: "Merchant",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_Merchant_Name",
                schema: "Management",
                table: "Merchant",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Merchant_PictureId",
                schema: "Management",
                table: "Merchant",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CreationTime",
                schema: "Finance",
                table: "Order",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_Order_MerchantId",
                schema: "Finance",
                table: "Order",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_CreationTime",
                schema: "Finance",
                table: "OrderItem",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                schema: "Finance",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                schema: "Finance",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_CreationTime",
                schema: "Media",
                table: "Picture",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                schema: "Catalog",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CreationTime",
                schema: "Catalog",
                table: "Product",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Name",
                schema: "Catalog",
                table: "Product",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPicture_CreationTime",
                schema: "Media",
                table: "ProductPicture",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPicture_PictureId",
                schema: "Media",
                table: "ProductPicture",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPicture_ProductId",
                schema: "Media",
                table: "ProductPicture",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_CreationTime",
                schema: "Management",
                table: "Service",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_Service_MerchantId",
                schema: "Management",
                table: "Service",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Name",
                schema: "Management",
                table: "Service",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_User_CreationTime",
                schema: "Management",
                table: "User",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserGroupId",
                schema: "Management",
                table: "User",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_CreationTime",
                schema: "Management",
                table: "UserGroup",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_MerchantId",
                schema: "Management",
                table: "UserGroup",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_Name",
                schema: "Management",
                table: "UserGroup",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "License",
                schema: "Management");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "Management");

            migrationBuilder.DropTable(
                name: "MenuItemRight",
                schema: "Management");

            migrationBuilder.DropTable(
                name: "OrderItem",
                schema: "Finance");

            migrationBuilder.DropTable(
                name: "ProductPicture",
                schema: "Media");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Management");

            migrationBuilder.DropTable(
                name: "Service",
                schema: "Management");

            migrationBuilder.DropTable(
                name: "MenuItem",
                schema: "Management");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "Finance");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "UserGroup",
                schema: "Management");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Merchant",
                schema: "Management");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "Region");

            migrationBuilder.DropTable(
                name: "Picture",
                schema: "Media");

            migrationBuilder.DropTable(
                name: "District",
                schema: "Region");

            migrationBuilder.DropTable(
                name: "City",
                schema: "Region");
        }
    }
}
