using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairShopV2.Migrations
{
    /// <inheritdoc />
    public partial class SparePartStorageInitialFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpareParts_Service_ServiceId",
                table: "SpareParts");

            migrationBuilder.DropForeignKey(
                name: "FK_SparePartStorage_SpareParts_SparePartId",
                table: "SparePartStorage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SparePartStorage",
                table: "SparePartStorage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.RenameTable(
                name: "SparePartStorage",
                newName: "SparePartStorages");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameIndex(
                name: "IX_SparePartStorage_SparePartId",
                table: "SparePartStorages",
                newName: "IX_SparePartStorages_SparePartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SparePartStorages",
                table: "SparePartStorages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpareParts_Services_ServiceId",
                table: "SpareParts",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SparePartStorages_SpareParts_SparePartId",
                table: "SparePartStorages",
                column: "SparePartId",
                principalTable: "SpareParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpareParts_Services_ServiceId",
                table: "SpareParts");

            migrationBuilder.DropForeignKey(
                name: "FK_SparePartStorages_SpareParts_SparePartId",
                table: "SparePartStorages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SparePartStorages",
                table: "SparePartStorages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.RenameTable(
                name: "SparePartStorages",
                newName: "SparePartStorage");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameIndex(
                name: "IX_SparePartStorages_SparePartId",
                table: "SparePartStorage",
                newName: "IX_SparePartStorage_SparePartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SparePartStorage",
                table: "SparePartStorage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpareParts_Service_ServiceId",
                table: "SpareParts",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SparePartStorage_SpareParts_SparePartId",
                table: "SparePartStorage",
                column: "SparePartId",
                principalTable: "SpareParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
