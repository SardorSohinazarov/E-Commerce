using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    public partial class BranchTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Description", "Latitude", "Longitude", "Name" },
                values: new object[] { 1, "Ajoyib filialimiz", 60.0, 50.0, "Kukcha" });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Description", "Latitude", "Longitude", "Name" },
                values: new object[] { 2, "Bu ham juda ajoyib filial", 61.0, 56.0, "Chilonzor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
