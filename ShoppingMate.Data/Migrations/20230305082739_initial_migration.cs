using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingMate.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial_migration : Migration
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
                name: "ItemShoppingListJoint",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ShoppingListId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemShoppingListJoint", x => new { x.ItemId, x.ShoppingListId });
                    table.ForeignKey(
                        name: "FK_ItemShoppingListJoint_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemShoppingListJoint_ShoppingLists_ShoppingListId",
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
                    { 1, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(3807), null, true, "Clothes", null },
                    { 2, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(3821), null, true, "Household Appliances", null },
                    { 3, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(3822), null, true, "Food", null },
                    { 4, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(3822), null, true, "Furniture", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreateDate", "CreatedBy", "IsActive", "Name", "Price", "Stock", "UnitType", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(6225), null, true, "Blue Jean", 80m, 100, "piece", null },
                    { 2, 1, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(6228), null, true, "Leather Jacket", 150m, 100, "piece", null },
                    { 3, 1, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(6229), null, true, "Sweetshirt", 60m, 100, "piece", null },
                    { 4, 1, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(6231), null, true, "Dress", 200m, 100, "piece", null },
                    { 5, 2, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(6233), null, true, "Washing Machine", 500m, 50, "piece", null },
                    { 6, 2, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(6234), null, true, "Vacuum Cleaner", 70m, 50, "piece", null },
                    { 7, 2, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(6235), null, true, "Television", 400m, 50, "piece", null },
                    { 8, 2, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(6236), null, true, "Refrigerator", 650m, 50, "piece", null },
                    { 9, 3, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(6237), null, true, "Pasta", 3m, 250, "piece", null },
                    { 10, 3, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(6239), null, true, "Oil", 8m, 250, "piece", null },
                    { 11, 3, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(6240), null, true, "Milk", 5m, 250, "piece", null },
                    { 12, 3, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(6242), null, true, "Bread", 1m, 250, "piece", null },
                    { 13, 4, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(6243), null, true, "Chair", 20m, 150, "piece", null },
                    { 14, 4, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(6245), null, true, "Commode", 30m, 150, "piece", null },
                    { 15, 4, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(6246), null, true, "Seat", 50m, 150, "piece", null },
                    { 16, 4, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(6247), null, true, "Lampshade", 15m, 150, "piece", null }
                });

            migrationBuilder.InsertData(
                table: "ShoppingLists",
                columns: new[] { "Id", "CategoryId", "CompleteTime", "CreateDate", "CreatedBy", "IsActive", "IsCompleted", "Name", "TotalCost", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(7269), null, true, false, "Clothes List", 0.0, null },
                    { 2, 2, null, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(7273), null, true, false, "Household Appliances List", 0.0, null },
                    { 3, 3, null, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(7274), null, true, false, "Foods List", 0.0, null },
                    { 4, 4, null, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(7275), null, true, false, "Furnitures List", 0.0, null }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "IsActive", "IsBought", "ProductId", "Quantity", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(5105), null, true, false, 1, 3, null },
                    { 2, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(5112), null, true, false, 2, 1, null },
                    { 3, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(5114), null, true, false, 3, 5, null },
                    { 4, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(5114), null, true, false, 4, 2, null },
                    { 5, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(5115), null, true, false, 5, 1, null },
                    { 6, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(5117), null, true, false, 6, 1, null },
                    { 7, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(5118), null, true, false, 7, 2, null },
                    { 8, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(5119), null, true, false, 8, 1, null },
                    { 9, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(5120), null, true, false, 9, 10, null },
                    { 10, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(5121), null, true, false, 10, 2, null },
                    { 11, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(5122), null, true, false, 11, 5, null },
                    { 12, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(5123), null, true, false, 12, 3, null },
                    { 13, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(5124), null, true, false, 13, 4, null },
                    { 14, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(5125), null, true, false, 14, 1, null },
                    { 15, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(5125), null, true, false, 15, 2, null },
                    { 16, new DateTime(2023, 3, 5, 11, 27, 39, 688, DateTimeKind.Local).AddTicks(5126), null, true, false, 16, 5, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProductId",
                table: "Items",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemShoppingListJoint_ShoppingListId",
                table: "ItemShoppingListJoint",
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
                name: "ItemShoppingListJoint");

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
