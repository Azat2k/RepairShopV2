using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairShopV2.Migrations
{
    /// <inheritdoc />
    public partial class AddManufacturerToSparePart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "SpareParts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_ManufacturerId",
                table: "SpareParts",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpareParts_Manufacturers_ManufacturerId",
                table: "SpareParts",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpareParts_Manufacturers_ManufacturerId",
                table: "SpareParts");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropIndex(
                name: "IX_SpareParts_ManufacturerId",
                table: "SpareParts");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "SpareParts");
        }
    }
}
