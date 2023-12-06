using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    public partial class Orderupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FromBranchId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Orders");

            migrationBuilder.AddColumn<long>(
                name: "OrderId",
                table: "ProductLists",
                type: "bigint",
                nullable: true);

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
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 21, 2, 37, 897, DateTimeKind.Local).AddTicks(3792));

            migrationBuilder.CreateIndex(
                name: "IX_ProductLists_OrderId",
                table: "ProductLists",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLists_ProductId",
                table: "ProductLists",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLists_Orders_OrderId",
                table: "ProductLists",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLists_Products_ProductId",
                table: "ProductLists",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductLists_Orders_OrderId",
                table: "ProductLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLists_Products_ProductId",
                table: "ProductLists");

            migrationBuilder.DropIndex(
                name: "IX_ProductLists_OrderId",
                table: "ProductLists");

            migrationBuilder.DropIndex(
                name: "IX_ProductLists_ProductId",
                table: "ProductLists");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ProductLists");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "BasketId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "FromBranchId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Orders",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Orders",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 19, 30, 6, 549, DateTimeKind.Local).AddTicks(5128));

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 19, 30, 6, 549, DateTimeKind.Local).AddTicks(5159));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 19, 30, 6, 549, DateTimeKind.Local).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 19, 30, 6, 549, DateTimeKind.Local).AddTicks(7442));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 19, 30, 6, 549, DateTimeKind.Local).AddTicks(7445));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 19, 30, 6, 549, DateTimeKind.Local).AddTicks(7446));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 6, 19, 30, 6, 549, DateTimeKind.Local).AddTicks(7447));
        }
    }
}
