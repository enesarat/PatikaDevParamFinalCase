using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingMate.Data.Migrations
{
    /// <inheritdoc />
    public partial class relational_db_initial_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UnitType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ListDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    CompleteTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingLists_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    LastActivity = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ShoppingListId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsBought = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_ShoppingLists_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "IsActive", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 6, 23, 30, 53, 981, DateTimeKind.Local).AddTicks(5495), null, true, "Clothes", null },
                    { 2, new DateTime(2023, 3, 6, 23, 30, 53, 981, DateTimeKind.Local).AddTicks(5507), null, true, "Household Appliances", null },
                    { 3, new DateTime(2023, 3, 6, 23, 30, 53, 981, DateTimeKind.Local).AddTicks(5509), null, true, "Food", null },
                    { 4, new DateTime(2023, 3, 6, 23, 30, 53, 981, DateTimeKind.Local).AddTicks(5509), null, true, "Furniture", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreateDate", "CreatedBy", "IsActive", "Name", "Price", "Stock", "UnitType", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 3, 6, 23, 30, 53, 982, DateTimeKind.Local).AddTicks(5946), null, true, "Blue Jean", 80m, 100, "piece", null },
                    { 2, 1, new DateTime(2023, 3, 6, 23, 30, 53, 982, DateTimeKind.Local).AddTicks(5950), null, true, "Leather Jacket", 150m, 100, "piece", null },
                    { 3, 1, new DateTime(2023, 3, 6, 23, 30, 53, 982, DateTimeKind.Local).AddTicks(5952), null, true, "Sweetshirt", 60m, 100, "piece", null },
                    { 4, 1, new DateTime(2023, 3, 6, 23, 30, 53, 982, DateTimeKind.Local).AddTicks(5953), null, true, "Dress", 200m, 100, "piece", null },
                    { 5, 2, new DateTime(2023, 3, 6, 23, 30, 53, 982, DateTimeKind.Local).AddTicks(5954), null, true, "Washing Machine", 500m, 50, "piece", null },
                    { 6, 2, new DateTime(2023, 3, 6, 23, 30, 53, 982, DateTimeKind.Local).AddTicks(5956), null, true, "Vacuum Cleaner", 70m, 50, "piece", null },
                    { 7, 2, new DateTime(2023, 3, 6, 23, 30, 53, 982, DateTimeKind.Local).AddTicks(5957), null, true, "Television", 400m, 50, "piece", null },
                    { 8, 2, new DateTime(2023, 3, 6, 23, 30, 53, 982, DateTimeKind.Local).AddTicks(5958), null, true, "Refrigerator", 650m, 50, "piece", null },
                    { 9, 3, new DateTime(2023, 3, 6, 23, 30, 53, 982, DateTimeKind.Local).AddTicks(5959), null, true, "Pasta", 3m, 250, "piece", null },
                    { 10, 3, new DateTime(2023, 3, 6, 23, 30, 53, 982, DateTimeKind.Local).AddTicks(5961), null, true, "Oil", 8m, 250, "piece", null },
                    { 11, 3, new DateTime(2023, 3, 6, 23, 30, 53, 982, DateTimeKind.Local).AddTicks(5962), null, true, "Milk", 5m, 250, "piece", null },
                    { 12, 3, new DateTime(2023, 3, 6, 23, 30, 53, 982, DateTimeKind.Local).AddTicks(5964), null, true, "Bread", 1m, 250, "piece", null },
                    { 13, 4, new DateTime(2023, 3, 6, 23, 30, 53, 982, DateTimeKind.Local).AddTicks(5966), null, true, "Chair", 20m, 150, "piece", null },
                    { 14, 4, new DateTime(2023, 3, 6, 23, 30, 53, 982, DateTimeKind.Local).AddTicks(5967), null, true, "Commode", 30m, 150, "piece", null },
                    { 15, 4, new DateTime(2023, 3, 6, 23, 30, 53, 982, DateTimeKind.Local).AddTicks(5968), null, true, "Seat", 50m, 150, "piece", null },
                    { 16, 4, new DateTime(2023, 3, 6, 23, 30, 53, 982, DateTimeKind.Local).AddTicks(5969), null, true, "Lampshade", 15m, 150, "piece", null }
                });

            migrationBuilder.InsertData(
                table: "ShoppingLists",
                columns: new[] { "Id", "CategoryId", "CompleteTime", "CreateDate", "CreatedBy", "IsActive", "IsCompleted", "ListDescription", "Name", "Note", "TotalCost", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2023, 3, 6, 23, 30, 53, 982, DateTimeKind.Local).AddTicks(7138), null, true, false, null, "Clothes List", null, 0.0, null },
                    { 2, 2, null, new DateTime(2023, 3, 6, 23, 30, 53, 982, DateTimeKind.Local).AddTicks(7190), null, true, false, null, "Household Appliances List", null, 0.0, null },
                    { 3, 3, null, new DateTime(2023, 3, 6, 23, 30, 53, 982, DateTimeKind.Local).AddTicks(7192), null, true, false, null, "Foods List", null, 0.0, null },
                    { 4, 4, null, new DateTime(2023, 3, 6, 23, 30, 53, 982, DateTimeKind.Local).AddTicks(7192), null, true, false, null, "Furnitures List", null, 0.0, null }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "IsActive", "IsBought", "ProductId", "Quantity", "ShoppingListId", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 6, 23, 30, 53, 981, DateTimeKind.Local).AddTicks(6961), null, true, false, 1, 3, 1, null },
                    { 2, new DateTime(2023, 3, 6, 23, 30, 53, 981, DateTimeKind.Local).AddTicks(6968), null, true, false, 2, 1, 1, null },
                    { 3, new DateTime(2023, 3, 6, 23, 30, 53, 981, DateTimeKind.Local).AddTicks(6969), null, true, false, 3, 5, 1, null },
                    { 4, new DateTime(2023, 3, 6, 23, 30, 53, 981, DateTimeKind.Local).AddTicks(6971), null, true, false, 4, 2, 1, null },
                    { 5, new DateTime(2023, 3, 6, 23, 30, 53, 981, DateTimeKind.Local).AddTicks(6972), null, true, false, 5, 1, 2, null },
                    { 6, new DateTime(2023, 3, 6, 23, 30, 53, 981, DateTimeKind.Local).AddTicks(7006), null, true, false, 6, 1, 2, null },
                    { 7, new DateTime(2023, 3, 6, 23, 30, 53, 981, DateTimeKind.Local).AddTicks(7008), null, true, false, 7, 2, 2, null },
                    { 8, new DateTime(2023, 3, 6, 23, 30, 53, 981, DateTimeKind.Local).AddTicks(7009), null, true, false, 8, 1, 1, null },
                    { 9, new DateTime(2023, 3, 6, 23, 30, 53, 981, DateTimeKind.Local).AddTicks(7010), null, true, false, 9, 10, 3, null },
                    { 10, new DateTime(2023, 3, 6, 23, 30, 53, 981, DateTimeKind.Local).AddTicks(7011), null, true, false, 10, 2, 3, null },
                    { 11, new DateTime(2023, 3, 6, 23, 30, 53, 981, DateTimeKind.Local).AddTicks(7012), null, true, false, 11, 5, 3, null },
                    { 12, new DateTime(2023, 3, 6, 23, 30, 53, 981, DateTimeKind.Local).AddTicks(7013), null, true, false, 12, 3, 3, null },
                    { 13, new DateTime(2023, 3, 6, 23, 30, 53, 981, DateTimeKind.Local).AddTicks(7014), null, true, false, 13, 4, 4, null },
                    { 14, new DateTime(2023, 3, 6, 23, 30, 53, 981, DateTimeKind.Local).AddTicks(7015), null, true, false, 14, 1, 4, null },
                    { 15, new DateTime(2023, 3, 6, 23, 30, 53, 981, DateTimeKind.Local).AddTicks(7016), null, true, false, 15, 2, 4, null },
                    { 16, new DateTime(2023, 3, 6, 23, 30, 53, 981, DateTimeKind.Local).AddTicks(7017), null, true, false, 16, 5, 4, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleId",
                table: "Accounts",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProductId",
                table: "Items",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShoppingListId",
                table: "Items",
                column: "ShoppingListId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_CategoryId",
                table: "ShoppingLists",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingLists");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
