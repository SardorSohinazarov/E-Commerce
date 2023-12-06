using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    public partial class ProductSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "ImagePath", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 6, 5, 24, 36, 245, DateTimeKind.Local).AddTicks(894), "Qimmat choy", "D:\\Projects\\E-Commerce\\src\\E-Commerce.Bot\\wwwroot\\products\\turkiya-choyi.jpg", "Turkiya choylari", 20000m },
                    { 2, 1, new DateTime(2023, 12, 6, 5, 24, 36, 245, DateTimeKind.Local).AddTicks(901), "O'rta narxdagi choy", "D:\\Projects\\E-Commerce\\src\\E-Commerce.Bot\\wwwroot\\products\\china-tea.jpg", "Xitoy choylari", 10000m },
                    { 3, 1, new DateTime(2023, 12, 6, 5, 24, 36, 245, DateTimeKind.Local).AddTicks(902), "Arzon choy", "D:\\Projects\\E-Commerce\\src\\E-Commerce.Bot\\wwwroot\\products\\Indian-tea.jpg", "Hindiston choylari", 5000m },
                    { 4, 8, new DateTime(2023, 12, 6, 5, 24, 36, 245, DateTimeKind.Local).AddTicks(903), "Daxshat kabob", "D:\\Projects\\E-Commerce\\src\\E-Commerce.Bot\\wwwroot\\products\\tovuq-kabob.jpg", "Tovuqli kabob", 13000m },
                    { 5, 8, new DateTime(2023, 12, 6, 5, 24, 36, 245, DateTimeKind.Local).AddTicks(905), "Ajoyib kabob", "D:\\Projects\\E-Commerce\\src\\E-Commerce.Bot\\wwwroot\\products\\go'shtli-kabob.jpg", "Go'shtli kabob", 2m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 4, 22, 20, 786, DateTimeKind.Local).AddTicks(2756));

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 4, 22, 20, 786, DateTimeKind.Local).AddTicks(2775));
        }
    }
}
