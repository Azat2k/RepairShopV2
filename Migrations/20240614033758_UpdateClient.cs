using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairShopV2.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientCompanies_ClientCompanyId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "ClientCompanyId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientCompanies_ClientCompanyId",
                table: "Clients",
                column: "ClientCompanyId",
                principalTable: "ClientCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientCompanies_ClientCompanyId",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "ClientCompanyId",
                table: "Clients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientCompanies_ClientCompanyId",
                table: "Clients",
                column: "ClientCompanyId",
                principalTable: "ClientCompanies",
                principalColumn: "Id");
        }
    }
}
