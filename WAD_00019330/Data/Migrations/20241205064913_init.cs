using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAD_00019330.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpareCategories",
                columns: table => new
                {
                    SpareCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpareCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpareCategories", x => x.SpareCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "SpareParts",
                columns: table => new
                {
                    SparePartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SparePartName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SparePartQuantity = table.Column<int>(type: "int", nullable: false),
                    SparePartPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SparePartCategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpareParts", x => x.SparePartId);
                    table.ForeignKey(
                        name: "FK_SpareParts_SpareCategories_SparePartCategoryID",
                        column: x => x.SparePartCategoryID,
                        principalTable: "SpareCategories",
                        principalColumn: "SpareCategoryId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_SparePartCategoryID",
                table: "SpareParts",
                column: "SparePartCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpareParts");

            migrationBuilder.DropTable(
                name: "SpareCategories");
        }
    }
}
