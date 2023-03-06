using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingMate.Data.Migrations
{
    /// <inheritdoc />
    public partial class refresh_token_for_account_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpireDate",
                table: "Accounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(1796));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(1806));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(1807));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(1808));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(3025));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(3029));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(3032));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(3033));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(3035));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(3036));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(3037));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(3039));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(3040));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(3041));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(4052));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(4053));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(4056));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(4057));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(4059));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(4060));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(4061));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(4062));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(4063));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(4065));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(4066));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(4068));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(4069));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(4070));

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(5074));

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(5078));

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 10, 14, 44, 834, DateTimeKind.Local).AddTicks(5079));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpireDate",
                table: "Accounts");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 244, DateTimeKind.Local).AddTicks(9185));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 244, DateTimeKind.Local).AddTicks(9198));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 244, DateTimeKind.Local).AddTicks(9199));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 244, DateTimeKind.Local).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(467));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(471));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(473));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(474));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(475));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(475));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(476));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(477));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(478));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(479));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(480));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(481));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(482));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(482));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(483));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(484));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(1672));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(1676));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(1677));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(1678));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(1680));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(1681));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(1682));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(1683));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(1684));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(1686));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(1687));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(1689));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(1690));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(1691));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(1693));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(1694));

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(2799));

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(2803));

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(2804));

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 3, 5, 13, 54, 25, 245, DateTimeKind.Local).AddTicks(2805));
        }
    }
}
