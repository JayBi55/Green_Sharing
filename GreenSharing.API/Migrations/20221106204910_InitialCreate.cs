using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenSharing.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.EnsureSchema(
                name: "location");

            migrationBuilder.CreateTable(
                name: "AccountType",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddressType",
                schema: "location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisabledDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceInfo",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VersionString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventPriority",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPriority", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OAuthProvider",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OAuthProvider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsConsentAccepted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisabledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConsentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_AccountType_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalSchema: "identity",
                        principalTable: "AccountType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountLocation",
                schema: "location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("7b22ddb4-48b0-456d-8ada-ec438b8df9b1")),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Door = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longtitude = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountLocation_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "identity",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountLocation_AddressType_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalSchema: "location",
                        principalTable: "AddressType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountOAuth",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OAuthProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserProviderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEmailVerified = table.Column<bool>(type: "bit", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOAuth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountOAuth_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "identity",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountOAuth_OAuthProvider_OAuthProviderId",
                        column: x => x.OAuthProviderId,
                        principalSchema: "identity",
                        principalTable: "OAuthProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountPassword",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPassword", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountPassword_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "identity",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountPassword_Account_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "identity",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountSession",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenFcm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLoginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualLoginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountSession_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "identity",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountSession_DeviceInfo_DeviceInfoId",
                        column: x => x.DeviceInfoId,
                        principalSchema: "identity",
                        principalTable: "DeviceInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankFood",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Availability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistanceMax = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankFood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankFood_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "identity",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Farmer",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Availability = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Farmer_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "identity",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gleaner",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistanceMax = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gleaner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gleaner_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "identity",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankFoodProductConsumable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    BankFoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankFoodProductConsumable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankFoodProductConsumable_BankFood_BankFoodId",
                        column: x => x.BankFoodId,
                        principalSchema: "identity",
                        principalTable: "BankFood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankFoodProductConsumable_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankFoodReview",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Score = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    BankFoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankFoodReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankFoodReview_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "identity",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankFoodReview_BankFood_BankFoodId",
                        column: x => x.BankFoodId,
                        principalSchema: "identity",
                        principalTable: "BankFood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FarmerProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    FarmerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmerProduct_Farmer_FarmerId",
                        column: x => x.FarmerId,
                        principalSchema: "identity",
                        principalTable: "Farmer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmerProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FarmerReview",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Score = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    FarmerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmerReview_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "identity",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmerReview_Farmer_FarmerId",
                        column: x => x.FarmerId,
                        principalSchema: "identity",
                        principalTable: "Farmer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GleanerReview",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Score = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    GleanerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GleanerReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GleanerReview_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "identity",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GleanerReview_Gleaner_GleanerId",
                        column: x => x.GleanerId,
                        principalSchema: "identity",
                        principalTable: "Gleaner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Duration = table.Column<long>(type: "bigint", nullable: false),
                    GleanedQuantity = table.Column<long>(type: "bigint", nullable: false),
                    MinimumCapacity = table.Column<long>(type: "bigint", nullable: false, defaultValue: 5L),
                    CarpoolingPlaces = table.Column<long>(type: "bigint", nullable: false),
                    IsCarpoolingEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Door = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    FarmerProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventPriorityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_EventPriority_EventPriorityId",
                        column: x => x.EventPriorityId,
                        principalTable: "EventPriority",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Event_FarmerProduct_FarmerProductId",
                        column: x => x.FarmerProductId,
                        principalTable: "FarmerProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventReview",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventReview_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "identity",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventReview_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventSubscription",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carpooling = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GleanerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSubscription_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventSubscription_Gleaner_GleanerId",
                        column: x => x.GleanerId,
                        principalSchema: "identity",
                        principalTable: "Gleaner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "EventPriority",
                columns: new[] { "Id", "Code", "IsActive", "IsDeleted", "Notes" },
                values: new object[,]
                {
                    { new Guid("2ed145ee-4231-4b52-a97a-2d89442a8742"), "RED", true, false, "Urgent" },
                    { new Guid("1dedacaa-28f1-45fe-ad06-5e28a7a8e5d2"), "ORANGE", true, false, "Medium" },
                    { new Guid("77d86c1f-ffd7-49c4-ac5a-df4f7f054517"), "YELLOW", true, false, "Moderate" },
                    { new Guid("0f824a56-5507-4dd2-b694-879d2edfe36c"), "VERT", true, false, "Normal" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "IsActive", "IsDeleted", "Name", "Notes" },
                values: new object[,]
                {
                    { new Guid("c5a7d3a5-365d-4cba-a48e-1bbf6f39fdad"), true, false, "Vegetable", "Vegetable" },
                    { new Guid("b57f1520-9f64-4442-8414-a2b2dfdb8d13"), true, false, "Animal", "Animal" },
                    { new Guid("37183ebb-9c7f-41e8-8b55-3bf292a37c25"), true, false, "Other", "Other" }
                });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "AccountType",
                columns: new[] { "Id", "ClosingDate", "CreationDate", "IsActive", "IsDeleted", "Name", "NameKey" },
                values: new object[,]
                {
                    { new Guid("35049d72-c586-4bed-92b0-918fd61ca92e"), null, new DateTime(2022, 11, 6, 20, 49, 9, 76, DateTimeKind.Utc).AddTicks(4222), true, false, "Farmer", "Farmer" },
                    { new Guid("9efcc1a2-ddf1-4ac4-b1d4-0e406a3bb6f3"), null, new DateTime(2022, 11, 6, 20, 49, 9, 76, DateTimeKind.Utc).AddTicks(4893), true, false, "BankFood", "BankFood" },
                    { new Guid("e406461d-d732-4f4f-917f-a69128cb0599"), null, new DateTime(2022, 11, 6, 20, 49, 9, 76, DateTimeKind.Utc).AddTicks(4901), true, false, "Gleaner", "Gleaner" }
                });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "OAuthProvider",
                columns: new[] { "Id", "IsActive", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("ede4680a-eb19-43db-82c9-2bdfe61c0e2c"), true, false, "Google" },
                    { new Guid("7756997b-5808-434d-ad43-7e2d28b06a84"), true, false, "Apple" },
                    { new Guid("f35e5759-a9a5-4ea9-8c96-3c900fedde91"), true, false, "Facebook" }
                });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "Account",
                columns: new[] { "Id", "AccountTypeId", "ConsentDate", "CreationDate", "DisabledDate", "Email", "FaxNumber", "FirstName", "IsActive", "IsConsentAccepted", "IsDeleted", "IsEnabled", "LastName", "Password", "PhoneNumber", "SurName", "UserName" },
                values: new object[] { new Guid("5985ba59-583b-49dc-9b44-fbb21382899f"), new Guid("35049d72-c586-4bed-92b0-918fd61ca92e"), null, new DateTime(2022, 11, 6, 20, 49, 9, 346, DateTimeKind.Utc).AddTicks(971), null, "farmer@yopmail.com", null, "Farmer", true, true, false, true, "John Doe", "AQAAAAEAACcQAAAAEAxBcWKtdM3s6Z/0uO95tjAsOrvXe4y2EsX3hdxtcehCFAWWTNuaNaG0vTWqDyzuqA==", null, "Big J.", null });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "Account",
                columns: new[] { "Id", "AccountTypeId", "ConsentDate", "CreationDate", "DisabledDate", "Email", "FaxNumber", "FirstName", "IsActive", "IsConsentAccepted", "IsDeleted", "IsEnabled", "LastName", "Password", "PhoneNumber", "SurName", "UserName" },
                values: new object[] { new Guid("46fa891c-1ae4-4373-aaa8-1125432ce9be"), new Guid("9efcc1a2-ddf1-4ac4-b1d4-0e406a3bb6f3"), null, new DateTime(2022, 11, 6, 20, 49, 9, 355, DateTimeKind.Utc).AddTicks(1620), null, "bankFood@yopmail.com", null, "Moisson Montreal", true, true, false, true, "Moisson Montreal", "AQAAAAEAACcQAAAAEIUNOKQUptJeZTBmOTTXRP9Yx49wiufSZyPbjPzBiphCwRZ+PvNbc2kykI3NNlxE+w==", null, "Give Back to Community", null });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "Account",
                columns: new[] { "Id", "AccountTypeId", "ConsentDate", "CreationDate", "DisabledDate", "Email", "FaxNumber", "FirstName", "IsActive", "IsConsentAccepted", "IsDeleted", "IsEnabled", "LastName", "Password", "PhoneNumber", "SurName", "UserName" },
                values: new object[] { new Guid("fdc6aa3d-7eea-454c-a1aa-f76722087cd3"), new Guid("e406461d-d732-4f4f-917f-a69128cb0599"), null, new DateTime(2022, 11, 6, 20, 49, 9, 363, DateTimeKind.Utc).AddTicks(3808), null, "gleaner@yopmail.com", null, "Gleaner", true, true, false, true, "Jeanette Odu", "AQAAAAEAACcQAAAAEG1QiDze9hfweQkiDKeQqWO/0aOJdgfBbA1/ivwIxcJBlId2O3GPQZdxaPqmmf6Yow==", null, "Jeane", null });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountTypeId",
                schema: "identity",
                table: "Account",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_Email",
                schema: "identity",
                table: "Account",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Account_UserName",
                schema: "identity",
                table: "Account",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AccountLocation_AccountId",
                schema: "location",
                table: "AccountLocation",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountLocation_AddressTypeId",
                schema: "location",
                table: "AccountLocation",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOAuth_AccountId",
                schema: "identity",
                table: "AccountOAuth",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOAuth_OAuthProviderId",
                schema: "identity",
                table: "AccountOAuth",
                column: "OAuthProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountPassword_AccountId",
                schema: "identity",
                table: "AccountPassword",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountPassword_AuthorId",
                schema: "identity",
                table: "AccountPassword",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountSession_AccountId",
                schema: "identity",
                table: "AccountSession",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountSession_DeviceInfoId",
                schema: "identity",
                table: "AccountSession",
                column: "DeviceInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountType_Name",
                schema: "identity",
                table: "AccountType",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BankFood_AccountId",
                schema: "identity",
                table: "BankFood",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankFoodProductConsumable_BankFoodId",
                table: "BankFoodProductConsumable",
                column: "BankFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_BankFoodProductConsumable_ProductId",
                table: "BankFoodProductConsumable",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BankFoodReview_AccountId",
                table: "BankFoodReview",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankFoodReview_BankFoodId",
                table: "BankFoodReview",
                column: "BankFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventPriorityId",
                table: "Event",
                column: "EventPriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_FarmerProductId",
                table: "Event",
                column: "FarmerProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EventPriority_Code",
                table: "EventPriority",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EventReview_AccountId",
                table: "EventReview",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_EventReview_EventId",
                table: "EventReview",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSubscription_EventId",
                table: "EventSubscription",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSubscription_GleanerId",
                table: "EventSubscription",
                column: "GleanerId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmer_AccountId",
                schema: "identity",
                table: "Farmer",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerProduct_FarmerId",
                table: "FarmerProduct",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerProduct_ProductId",
                table: "FarmerProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerReview_AccountId",
                table: "FarmerReview",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerReview_FarmerId",
                table: "FarmerReview",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Gleaner_AccountId",
                schema: "identity",
                table: "Gleaner",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_GleanerReview_AccountId",
                table: "GleanerReview",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_GleanerReview_GleanerId",
                table: "GleanerReview",
                column: "GleanerId");

            migrationBuilder.CreateIndex(
                name: "IX_OAuthProvider_Name",
                schema: "identity",
                table: "OAuthProvider",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeId",
                table: "Product",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_Name",
                table: "ProductType",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountLocation",
                schema: "location");

            migrationBuilder.DropTable(
                name: "AccountOAuth",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "AccountPassword",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "AccountSession",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "BankFoodProductConsumable");

            migrationBuilder.DropTable(
                name: "BankFoodReview");

            migrationBuilder.DropTable(
                name: "EventReview");

            migrationBuilder.DropTable(
                name: "EventSubscription");

            migrationBuilder.DropTable(
                name: "FarmerReview");

            migrationBuilder.DropTable(
                name: "GleanerReview");

            migrationBuilder.DropTable(
                name: "AddressType",
                schema: "location");

            migrationBuilder.DropTable(
                name: "OAuthProvider",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "DeviceInfo",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "BankFood",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Gleaner",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "EventPriority");

            migrationBuilder.DropTable(
                name: "FarmerProduct");

            migrationBuilder.DropTable(
                name: "Farmer",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "AccountType",
                schema: "identity");
        }
    }
}
