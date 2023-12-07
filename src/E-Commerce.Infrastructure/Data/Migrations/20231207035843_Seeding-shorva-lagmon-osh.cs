using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    public partial class Seedingshorvalagmonosh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 8, 58, 43, 41, DateTimeKind.Local).AddTicks(2254));

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 8, 58, 43, 41, DateTimeKind.Local).AddTicks(2299));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 8, 58, 43, 41, DateTimeKind.Local).AddTicks(4609));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 8, 58, 43, 41, DateTimeKind.Local).AddTicks(4629));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 8, 58, 43, 41, DateTimeKind.Local).AddTicks(4631));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 8, 58, 43, 41, DateTimeKind.Local).AddTicks(4632));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 8, 58, 43, 41, DateTimeKind.Local).AddTicks(4633));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 8, 58, 43, 41, DateTimeKind.Local).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 8, 58, 43, 41, DateTimeKind.Local).AddTicks(4638));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "ImagePath", "Name", "Price" },
                values: new object[,]
                {
                    { 8, 4, new DateTime(2023, 12, 7, 8, 58, 43, 41, DateTimeKind.Local).AddTicks(4639), "Juda shirin va mazali", "https://i2.wp.com/attuale.ru/wp-content/uploads/2018/02/50270956-391b-4308-b21d-882911a30634_original.jpg", "Tovuq shorva", 18000m },
                    { 9, 4, new DateTime(2023, 12, 7, 8, 58, 43, 41, DateTimeKind.Local).AddTicks(4641), "Juda shirin va mazali", "https://www.ferganatourism.uz/d/bd72b97a.jpg", "Noxat shorva", 16000m },
                    { 10, 5, new DateTime(2023, 12, 7, 8, 58, 43, 41, DateTimeKind.Local).AddTicks(4643), "Juda shirin va mazali", "https://pazanda.com/wp-content/uploads/2017/02/img_4051.jpg", "Qovurma lag'mon", 14000m },
                    { 11, 6, new DateTime(2023, 12, 7, 8, 58, 43, 41, DateTimeKind.Local).AddTicks(4644), "Juda shirin va mazali", "https://pazanda.com/wp-content/uploads/2017/02/img_4051.jpg", "Choyxona palov", 25000m },
                    { 12, 6, new DateTime(2023, 12, 7, 8, 58, 43, 41, DateTimeKind.Local).AddTicks(4645), "Juda shirin va mazali", "https://pazanda.com/wp-content/uploads/2017/02/img_4051.jpg", "To'y oshi", 25000m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

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
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 8, 44, 45, 551, DateTimeKind.Local).AddTicks(9606));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 8, 44, 45, 551, DateTimeKind.Local).AddTicks(9609));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 8, 44, 45, 551, DateTimeKind.Local).AddTicks(9610));
        }
    }
}
