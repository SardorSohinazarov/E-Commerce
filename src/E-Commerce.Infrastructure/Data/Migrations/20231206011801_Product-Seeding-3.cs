using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    public partial class ProductSeeding3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 6, 18, 1, 287, DateTimeKind.Local).AddTicks(5161));

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 6, 18, 1, 287, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImagePath" },
                values: new object[] { new DateTime(2023, 12, 6, 6, 18, 1, 287, DateTimeKind.Local).AddTicks(6544), "https://idsb.tmgrup.com.tr/ly/uploads/images/2022/05/15/205578.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImagePath" },
                values: new object[] { new DateTime(2023, 12, 6, 6, 18, 1, 287, DateTimeKind.Local).AddTicks(6552), "https://domf5oio6qrcr.cloudfront.net/medialibrary/8468/Tea.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImagePath" },
                values: new object[] { new DateTime(2023, 12, 6, 6, 18, 1, 287, DateTimeKind.Local).AddTicks(6554), "https://realfood.tesco.com/media/images/178-Chaispicedtea-H-efb63a82-e983-4d3c-9e3d-cb799a6f0418-0-472x310.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ImagePath" },
                values: new object[] { new DateTime(2023, 12, 6, 6, 18, 1, 287, DateTimeKind.Local).AddTicks(6556), "https://1.bp.blogspot.com/-xRoG8l4BZK8/XfasALaj1QI/AAAAAAAAPVI/RImASf05UKAvC7uwZsXsl9vERmS2W7zCwCNcBGAsYHQ/s1600/Chicken%2BKabob.JPG" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ImagePath" },
                values: new object[] { new DateTime(2023, 12, 6, 6, 18, 1, 287, DateTimeKind.Local).AddTicks(6557), "https://foodiesterminal.com/wp-content/uploads/2019/11/chicken-angara-kabab-2-679x1024.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "CreatedDate", "ImagePath" },
                values: new object[] { new DateTime(2023, 12, 6, 5, 40, 12, 953, DateTimeKind.Local).AddTicks(1405), "D:\\Projects\\E-Commerce\\src\\E-Commerce.Bot\\wwwroot\\products\\turkiya-choyi.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImagePath" },
                values: new object[] { new DateTime(2023, 12, 6, 5, 40, 12, 953, DateTimeKind.Local).AddTicks(1414), "D:\\Projects\\E-Commerce\\src\\E-Commerce.Bot\\wwwroot\\products\\china-tea.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImagePath" },
                values: new object[] { new DateTime(2023, 12, 6, 5, 40, 12, 953, DateTimeKind.Local).AddTicks(1416), "D:\\Projects\\E-Commerce\\src\\E-Commerce.Bot\\wwwroot\\products\\Indian-tea.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ImagePath" },
                values: new object[] { new DateTime(2023, 12, 6, 5, 40, 12, 953, DateTimeKind.Local).AddTicks(1418), "D:\\Projects\\E-Commerce\\src\\E-Commerce.Bot\\wwwroot\\products\\tovuq-kabob.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ImagePath" },
                values: new object[] { new DateTime(2023, 12, 6, 5, 40, 12, 953, DateTimeKind.Local).AddTicks(1420), "D:\\Projects\\E-Commerce\\src\\E-Commerce.Bot\\wwwroot\\products\\go'shtli-kabob.jpg" });
        }
    }
}
