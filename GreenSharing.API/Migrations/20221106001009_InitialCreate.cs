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
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventPriority",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPriority", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    ConsentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccountTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountTypeId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_AccountType_AccountTypeId1",
                        column: x => x.AccountTypeId1,
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
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longtitude = table.Column<double>(type: "float", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistanceMax = table.Column<long>(type: "bigint", nullable: false),
                    Score = table.Column<long>(type: "bigint", nullable: false),
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
                    FarmerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmerReview_Account_AccountID",
                        column: x => x.AccountID,
                        principalSchema: "identity",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmerReview_Farmer_FarmerID",
                        column: x => x.FarmerID,
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountTypeId1",
                schema: "identity",
                table: "Account",
                column: "AccountTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_AccountLocation_AccountId",
                schema: "location",
                table: "AccountLocation",
                column: "AccountId");

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
                name: "IX_FarmerReview_AccountID",
                table: "FarmerReview",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerReview_FarmerID",
                table: "FarmerReview",
                column: "FarmerID");

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
                name: "IX_Product_ProductTypeId",
                table: "Product",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountLocation",
                schema: "location");

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
                name: "AccountType");
        }
    }
}
