using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    public partial class ProductSeeding2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 5, 40, 12, 952, DateTimeKind.Local).AddTicks(9514));

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 5, 40, 12, 952, DateTimeKind.Local).AddTicks(9551));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 5, 40, 12, 953, DateTimeKind.Local).AddTicks(1405));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 5, 40, 12, 953, DateTimeKind.Local).AddTicks(1414));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 5, 40, 12, 953, DateTimeKind.Local).AddTicks(1416));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "CreatedDate" },
                values: new object[] { 2, new DateTime(2023, 12, 6, 5, 40, 12, 953, DateTimeKind.Local).AddTicks(1418) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "CreatedDate" },
                values: new object[] { 2, new DateTime(2023, 12, 6, 5, 40, 12, 953, DateTimeKind.Local).AddTicks(1420) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 5, 24, 36, 244, DateTimeKind.Local).AddTicks(9663));

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 5, 24, 36, 244, DateTimeKind.Local).AddTicks(9685));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 5, 24, 36, 245, DateTimeKind.Local).AddTicks(894));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 5, 24, 36, 245, DateTimeKind.Local).AddTicks(901));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 5, 24, 36, 245, DateTimeKind.Local).AddTicks(902));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "CreatedDate" },
                values: new object[] { 8, new DateTime(2023, 12, 6, 5, 24, 36, 245, DateTimeKind.Local).AddTicks(903) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "CreatedDate" },
                values: new object[] { 8, new DateTime(2023, 12, 6, 5, 24, 36, 245, DateTimeKind.Local).AddTicks(905) });
        }
    }
}
