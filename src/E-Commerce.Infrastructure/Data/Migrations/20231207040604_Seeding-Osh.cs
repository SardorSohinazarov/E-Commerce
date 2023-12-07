using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    public partial class SeedingOsh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 6, 4, 573, DateTimeKind.Local).AddTicks(5491));

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 6, 4, 573, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 6, 4, 573, DateTimeKind.Local).AddTicks(7471));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 6, 4, 573, DateTimeKind.Local).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 6, 4, 573, DateTimeKind.Local).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 6, 4, 573, DateTimeKind.Local).AddTicks(7484));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 6, 4, 573, DateTimeKind.Local).AddTicks(7485));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 6, 4, 573, DateTimeKind.Local).AddTicks(7489));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 6, 4, 573, DateTimeKind.Local).AddTicks(7490));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 6, 4, 573, DateTimeKind.Local).AddTicks(7491));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 6, 4, 573, DateTimeKind.Local).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 6, 4, 573, DateTimeKind.Local).AddTicks(7494));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ImagePath" },
                values: new object[] { new DateTime(2023, 12, 7, 9, 6, 4, 573, DateTimeKind.Local).AddTicks(7496), "https://choyxonachi.uz/wp-content/uploads/2020/06/ab-5.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "ImagePath" },
                values: new object[] { new DateTime(2023, 12, 7, 9, 6, 4, 573, DateTimeKind.Local).AddTicks(7496), "https://pbs.twimg.com/media/El1uVoZXYAAXXGE.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 2, 35, 110, DateTimeKind.Local).AddTicks(1322));

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 2, 35, 110, DateTimeKind.Local).AddTicks(1340));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 2, 35, 110, DateTimeKind.Local).AddTicks(2353));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 2, 35, 110, DateTimeKind.Local).AddTicks(2359));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 2, 35, 110, DateTimeKind.Local).AddTicks(2360));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 2, 35, 110, DateTimeKind.Local).AddTicks(2361));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 2, 35, 110, DateTimeKind.Local).AddTicks(2362));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 2, 35, 110, DateTimeKind.Local).AddTicks(2364));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 2, 35, 110, DateTimeKind.Local).AddTicks(2365));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 2, 35, 110, DateTimeKind.Local).AddTicks(2366));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 2, 35, 110, DateTimeKind.Local).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 9, 2, 35, 110, DateTimeKind.Local).AddTicks(2368));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ImagePath" },
                values: new object[] { new DateTime(2023, 12, 7, 9, 2, 35, 110, DateTimeKind.Local).AddTicks(2369), "https://pazanda.com/wp-content/uploads/2017/02/img_4051.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "ImagePath" },
                values: new object[] { new DateTime(2023, 12, 7, 9, 2, 35, 110, DateTimeKind.Local).AddTicks(2370), "https://pazanda.com/wp-content/uploads/2017/02/img_4051.jpg" });
        }
    }
}
