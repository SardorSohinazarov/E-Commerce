using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    public partial class NonSeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 8, 44, 45, 551, DateTimeKind.Local).AddTicks(8224));

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 8, 44, 45, 551, DateTimeKind.Local).AddTicks(8249));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 8, 44, 45, 551, DateTimeKind.Local).AddTicks(9594));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 8, 44, 45, 551, DateTimeKind.Local).AddTicks(9602));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 8, 44, 45, 551, DateTimeKind.Local).AddTicks(9603));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 8, 44, 45, 551, DateTimeKind.Local).AddTicks(9605));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Price" },
                values: new object[] { new DateTime(2023, 12, 7, 8, 44, 45, 551, DateTimeKind.Local).AddTicks(9606), 15000m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "ImagePath", "Name", "Price" },
                values: new object[,]
                {
                    { 6, 3, new DateTime(2023, 12, 7, 8, 44, 45, 551, DateTimeKind.Local).AddTicks(9609), "Juda shirin va mazali", "https://api.online-bozor.uz/uploads/images/ff80818144829954794c12d7", "Qo'qon Patir", 10000m },
                    { 7, 3, new DateTime(2023, 12, 7, 8, 44, 45, 551, DateTimeKind.Local).AddTicks(9610), "Juda shirin va mazali", "https://storage.kun.uz/source/1/ssEjJUu1uNZtl84wFUwb11XwDH3wT1l0.jpg", "Buxanka", 2m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 21, 2, 37, 897, DateTimeKind.Local).AddTicks(2729));

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 21, 2, 37, 897, DateTimeKind.Local).AddTicks(2746));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 21, 2, 37, 897, DateTimeKind.Local).AddTicks(3781));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 21, 2, 37, 897, DateTimeKind.Local).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 21, 2, 37, 897, DateTimeKind.Local).AddTicks(3790));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 21, 2, 37, 897, DateTimeKind.Local).AddTicks(3791));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Price" },
                values: new object[] { new DateTime(2023, 12, 6, 21, 2, 37, 897, DateTimeKind.Local).AddTicks(3792), 2m });
        }
    }
}
