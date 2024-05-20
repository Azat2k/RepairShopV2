using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairShopV2.Migrations
{
    /// <inheritdoc />
    public partial class AddSupplierToSparePart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "SpareParts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Suppliers",
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
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_SupplierId",
                table: "SpareParts",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpareParts_Suppliers_SupplierId",
                table: "SpareParts",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpareParts_Suppliers_SupplierId",
                table: "SpareParts");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_SpareParts_SupplierId",
                table: "SpareParts");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "SpareParts");
        }
    }
}
