using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetHealthCenter.Infrastructure.Migrations
{
    public partial class SetupDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressText = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Adrres text - street, number, etc."),
                    TownName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Town name"),
                    ZipCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false, comment: "ZIP code of the town")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                },
                comment: "Addres properties");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true, comment: "User's first name"),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true, comment: "User's last name"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    UserName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                },
                comment: "Additional user properties");

            migrationBuilder.CreateTable(
                name: "SpecieTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Name of specie type")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecieTypes", x => x.Id);
                },
                comment: "Type of the animal's specie");

            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Job title")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.Id);
                },
                comment: "Possible job titles");

            migrationBuilder.CreateTable(
                name: "ProductComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of product component")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComponents", x => x.Id);
                },
                comment: "The components/parts of the animal, which can be affected by the services");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Name of the customer"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false, comment: "Phone number of the cusotmer"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Email of the customer"),
                    IsCorporate = table.Column<bool>(type: "bit", nullable: false, comment: "Defines if the customer is corporate or individual"),
                    Uic = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, comment: "The Unit Identification Code of the customer's company"),
                    AddressId = table.Column<int>(type: "int", nullable: true, comment: "The address of the customer's office"),
                    ResponsiblePerson = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true, comment: "Name of the responsible person of the customer's company")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                },
                comment: "Customer information");

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the supplier"),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the supplier's company"),
                    Uic = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Unit Identification Code of the supplier's company"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false, comment: "Phone number of the supplier's office"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Email of the supplier"),
                    AddressId = table.Column<int>(type: "int", nullable: false, comment: "Address of the supplier's office")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Supplier, who delivers parts to the pet health center");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Name of the service"),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false, comment: "Description of the service"),
                    Price = table.Column<decimal>(type: "money", precision: 18, scale: 2, nullable: false, comment: "Price of the service"),
                    ProductComponentId = table.Column<int>(type: "int", nullable: false, comment: "Affected part of the animal"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthServices_ProductComponents_ProductComponentId",
                        column: x => x.ProductComponentId,
                        principalTable: "ProductComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Services, offered by pet health center");

            migrationBuilder.CreateTable(
                name: "OperatingCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the document"),
                    DocumentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "The number of current document"),
                    PartId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    PetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperatingCards_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperatingCards_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Operating card for the current service");

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Pet make name"),
                    Model = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "Pet model name"),
                    IdentificationNUmber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false, comment: "Identification number of the animal"),
                    FIrstRegistration = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the first registration of the animal"),
                    SpecieTypeId = table.Column<int>(type: "int", nullable: false, comment: "Specie type of the animal"),
                    Power = table.Column<int>(type: "int", nullable: false, comment: "Specie power in Hp"),
                    VinNumber = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false, comment: "VIN number of the animal"),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_SpecieTypes_SpecieTypeId",
                        column: x => x.SpecieTypeId,
                        principalTable: "SpecieTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Pet, owned by customer");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Document number"),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the order"),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false, comment: "Supplier which will deliver the goods"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Order of parts properties");

            migrationBuilder.CreateTable(
                name: "OperatingCardHealthService",
                columns: table => new
                {
                    OperatingCardId = table.Column<int>(type: "int", nullable: false),
                    HealthServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingCardHealthService", x => new { x.OperatingCardId, x.HealthServiceId });
                    table.ForeignKey(
                        name: "FK_OperatingCardHealthService_OperatingCards_OperatingCardId",
                        column: x => x.OperatingCardId,
                        principalTable: "OperatingCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperatingCardHealthService_HealthServices_HealthServiceId",
                        column: x => x.HealthServiceId,
                        principalTable: "HealthServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The name of the part"),
                    ImageUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false, comment: "Part's availability"),
                    Manufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Manufacturer's name of the part"),
                    OriginalMpn = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Part's MPN by the car manufacturer"),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, comment: "Description of the part"),
                    PriceBuy = table.Column<decimal>(type: "money", precision: 18, scale: 2, nullable: false, comment: "Delivery price (by the supplier)"),
                    PriceSell = table.Column<decimal>(type: "money", precision: 18, scale: 2, nullable: false, comment: "Selling price (by the pet health center)"),
                    ProductComponentId = table.Column<int>(type: "int", nullable: false, comment: "Affected part of the animal, where the part may be used"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    HealthServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Parts_HealthServices_HealthServiceId",
                        column: x => x.HealthServiceId,
                        principalTable: "HealthServices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Parts_ProductComponents_ProductComponentId",
                        column: x => x.ProductComponentId,
                        principalTable: "ProductComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Part, stored in the shop's warehouse");

            migrationBuilder.CreateTable(
                name: "OperatingCardParts",
                columns: table => new
                {
                    OperatingCardId = table.Column<int>(type: "int", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingCardParts", x => new { x.OperatingCardId, x.PartId });
                    table.ForeignKey(
                        name: "FK_OperatingCardParts_OperatingCards_OperatingCardId",
                        column: x => x.OperatingCardId,
                        principalTable: "OperatingCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperatingCardParts_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierSparePart",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierSparePart", x => new { x.SupplierId, x.PartId });
                    table.ForeignKey(
                        name: "FK_SupplierSparePart_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierSparePart_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Mapping entity between suppliers and parts");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressText", "TownName", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Tsar Osvobodiltel str. 98", "Varna", "9000" },
                    { 2, "Slivnitsa blv. 108", "Varna", "9000" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("4d3bb951-2772-4ae8-b6bb-eb4e80426b0e"), 0, "71d9e096-281e-428d-85a0-e8fa800a7f65", "adviser_pet_health@mail.com", false, "Georgi", true, "Georgiev", false, null, "ADVISER_PET_HEALTH@MAIL.COM", "SERVICE_ADVISER", "AQAAAAEAACcQAAAAEEMlOaY0AHtIHDrmo040H77rvrYCAM6dyNy1JrU2LyVVEcGLM21CkqaaaX2ZD9Sa4w==", null, false, "780e294a-90d6-4b9f-987f-a958b729a0b3", false, "Service_Adviser" },
                    { new Guid("59bff60d-d8d8-4ca8-9da9-48149761e9db"), 0, "95cb6e27-a9c5-4d09-ae2e-e54370a14ac8", "doctor_pet_health@mail.com", false, "Petar", true, "Petrov", false, null, "DOCTOR_PET_HEALTH@MAIL.COM", "DOCTOR", "AQAAAAEAACcQAAAAEBu3bl1NakP25uHGEQS3/CyCtbfU62N5axnYuD5zM4p9Wm40on1lDYjVIQ/AOt4x4g==", null, false, "5755db6a-132e-475d-93b6-d6c2f46f6fad", false, "Doctor" },
                    { new Guid("8bc5851a-9b57-4d66-99ae-4bfd11f26bd2"), 0, "bb78c1ab-c0f8-4cc3-a9e1-66ad6edc325f", "manager_pet_health@mail.com", false, "Ivan", true, "Ivanov", false, null, "MANAGER_PET_HEALTH@MAIL.COM", "GENERAL_MANAGER", "AQAAAAEAACcQAAAAEE4/v/2mtFqYh4DTo5L5R4C2r6I+OW6d8zGsfgNhgc6It1O5zE78brG2WLRtfDkMMQ==", null, false, "70c7ac29-fc79-45e7-9d29-b922b7cd7f1e", false, "General_Manager" }
                });

            migrationBuilder.InsertData(
                table: "SpecieTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Gasoline" },
                    { 2, "Diesel" },
                    { 3, "Hybrid" },
                    { 4, "Electric" }
                });

            migrationBuilder.InsertData(
                table: "JobTitles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Manager" },
                    { 2, "Doctor" },
                    { 3, "Service adviser" }
                });

            migrationBuilder.InsertData(
                table: "ProductComponents",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Specie" },
                    { 2, "Tablets" },
                    { 3, "Front and rear axle" },
                    { 4, "Vaccine" },
                    { 5, "Suspenssion system" },
                    { 6, "Tyres and brakes" },
                    { 7, "Body" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "Email", "IsCorporate", "Name", "PhoneNumber", "ResponsiblePerson", "Uic" },
                values: new object[,]
                {
                    { 1, 1, "ivan.ivanov@abv.bg", true, "Ivanov.Inc", "099999999", "Ivan Ivanov", "1234543421234" },
                    { 2, 2, "boris.borisov@abv.bg", false, "Boris Borisov", "0898888888", null, null }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Description", "ImageUrl", "IsActive", "Manufacturer", "Name", "OrderId", "OriginalMpn", "PriceBuy", "PriceSell", "HealthServiceId", "Stock", "ProductComponentId" },
                values: new object[] { 1, "Cosequin Maximum Strength Plus MSM Joint Supplement for Dogs, 500 Chewable Tablets", "https://s.turbifycdn.com/aah/healthypetscom/2-pack-cosequin-ds-plus-msm-chewable-tablets-500-count-130.jpg", true, "Cosequin", "Cosequin Maximum Strength Tablets", null, "CHEWDS250-MSM-2PK", 99.98m, 114.56m, null, 4, 2 });

            migrationBuilder.InsertData(
                table: "HealthServices",
                columns: new[] { "Id", "Description", "IsActive", "Name", "Price", "ProductComponentId" },
                values: new object[] { 1, "Check the common health status and vaccination", true, "Diagnosis and vaccination", 65m, 4 });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "AddressId", "CompanyName", "Email", "Name", "PhoneNumber", "Uic" },
                values: new object[] { 1, 2, "Garvan EOOD", "garvan@abv.bg", "Garvan", "0898888888", "123456789876" });

            migrationBuilder.InsertData(
                table: "OperatingCards",
                columns: new[] { "Id", "ApplicationUserId", "CustomerId", "Date", "DocumentNumber", "IsActive", "PartId", "ServiceId", "PetId" },
                values: new object[] { 1, new Guid("59bff60d-d8d8-4ca8-9da9-48149761e9db"), 1, new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local), "000112/6/2022 12:00:00 AM", true, 0, 0, 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "IsActive", "IssueDate", "Note", "Number", "SupplierId" },
                values: new object[] { 1, true, new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local), "To arrive today", "0001/12/6/2022 12:00:00 AM", 1 });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "CustomerId", "SpecieTypeId", "FIrstRegistration", "IdentificationNUmber", "Make", "Model", "Power", "VinNumber" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2013, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "B5466HA", "Labrador", "American", 272, "12312324125" },
                    { 4, 2, 1, new DateTime(2013, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "B5432PA", "Husky", "Siberian", 156, "12312324642" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingCardParts_PartId",
                table: "OperatingCardParts",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingCards_ApplicationUserId",
                table: "OperatingCards",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingCards_CustomerId",
                table: "OperatingCards",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingCardHealthService_HealthServiceId",
                table: "OperatingCardHealthService",
                column: "HealthServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SupplierId",
                table: "Orders",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_OrderId",
                table: "Parts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_HealthServiceId",
                table: "Parts",
                column: "HealthServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_ProductComponentId",
                table: "Parts",
                column: "ProductComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthServices_ProductComponentId",
                table: "HealthServices",
                column: "ProductComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_AddressId",
                table: "Suppliers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierSparePart_PartId",
                table: "SupplierSparePart",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_CustomerId",
                table: "Pets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_SpecieTypeId",
                table: "Pets",
                column: "SpecieTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DropTable(
                name: "OperatingCardParts");

            migrationBuilder.DropTable(
                name: "OperatingCardHealthService");

            migrationBuilder.DropTable(
                name: "SupplierSparePart");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "OperatingCards");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "SpecieTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "HealthServices");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "ProductComponents");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
