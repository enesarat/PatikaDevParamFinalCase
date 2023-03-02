using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingMate.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "ItemsShoppingListsJoint",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ShoppingListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsShoppingListsJoint", x => new { x.ItemId, x.ShoppingListId });
                    table.ForeignKey(
                        name: "ItemFK",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ShoppingListFK",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "IsActive", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(6612), null, true, "Clothes", null },
                    { 2, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(6624), null, true, "Household Appliances", null },
                    { 3, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(6625), null, true, "Food", null },
                    { 4, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(6626), null, true, "Furniture", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreateDate", "CreatedBy", "IsActive", "Name", "Price", "Stock", "UnitType", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(9206), null, true, "Blue Jean", 80m, 100, "piece", null },
                    { 2, 1, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(9210), null, true, "Leather Jacket", 150m, 100, "piece", null },
                    { 3, 1, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(9212), null, true, "Sweetshirt", 60m, 100, "piece", null },
                    { 4, 1, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(9214), null, true, "Dress", 200m, 100, "piece", null },
                    { 5, 2, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(9215), null, true, "Washing Machine", 500m, 50, "piece", null },
                    { 6, 2, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(9216), null, true, "Vacuum Cleaner", 70m, 50, "piece", null },
                    { 7, 2, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(9217), null, true, "Television", 400m, 50, "piece", null },
                    { 8, 2, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(9219), null, true, "Refrigerator", 650m, 50, "piece", null },
                    { 9, 3, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(9220), null, true, "Pasta", 3m, 250, "piece", null },
                    { 10, 3, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(9221), null, true, "Oil", 8m, 250, "piece", null },
                    { 11, 3, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(9223), null, true, "Milk", 5m, 250, "piece", null },
                    { 12, 3, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(9224), null, true, "Bread", 1m, 250, "piece", null },
                    { 13, 4, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(9226), null, true, "Chair", 20m, 150, "piece", null },
                    { 14, 4, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(9228), null, true, "Commode", 30m, 150, "piece", null },
                    { 15, 4, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(9229), null, true, "Seat", 50m, 150, "piece", null },
                    { 16, 4, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(9230), null, true, "Lampshade", 15m, 150, "piece", null }
                });

            migrationBuilder.InsertData(
                table: "ShoppingLists",
                columns: new[] { "Id", "CategoryId", "CompleteTime", "CreateDate", "CreatedBy", "IsActive", "IsCompleted", "Name", "TotalCost", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2023, 3, 3, 1, 45, 42, 111, DateTimeKind.Local).AddTicks(394), null, true, false, "Clothes List", 0.0, null },
                    { 2, 2, null, new DateTime(2023, 3, 3, 1, 45, 42, 111, DateTimeKind.Local).AddTicks(397), null, true, false, "Household Appliances List", 0.0, null },
                    { 3, 3, null, new DateTime(2023, 3, 3, 1, 45, 42, 111, DateTimeKind.Local).AddTicks(398), null, true, false, "Foods List", 0.0, null },
                    { 4, 4, null, new DateTime(2023, 3, 3, 1, 45, 42, 111, DateTimeKind.Local).AddTicks(399), null, true, false, "Furnitures List", 0.0, null }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "IsActive", "IsBought", "ProductId", "Quantity", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(7975), null, true, false, 1, 3, null },
                    { 2, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(7980), null, true, false, 2, 1, null },
                    { 3, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(7981), null, true, false, 3, 5, null },
                    { 4, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(7982), null, true, false, 4, 2, null },
                    { 5, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(7983), null, true, false, 5, 1, null },
                    { 6, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(7984), null, true, false, 6, 1, null },
                    { 7, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(7985), null, true, false, 7, 2, null },
                    { 8, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(7986), null, true, false, 8, 1, null },
                    { 9, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(7987), null, true, false, 9, 10, null },
                    { 10, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(7988), null, true, false, 10, 2, null },
                    { 11, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(7989), null, true, false, 11, 5, null },
                    { 12, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(7990), null, true, false, 12, 3, null },
                    { 13, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(7991), null, true, false, 13, 4, null },
                    { 14, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(7991), null, true, false, 14, 1, null },
                    { 15, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(7992), null, true, false, 15, 2, null },
                    { 16, new DateTime(2023, 3, 3, 1, 45, 42, 110, DateTimeKind.Local).AddTicks(7993), null, true, false, 16, 5, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProductId",
                table: "Items",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsShoppingListsJoint_ShoppingListId",
                table: "ItemsShoppingListsJoint",
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
                name: "ItemsShoppingListsJoint");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ShoppingLists");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
