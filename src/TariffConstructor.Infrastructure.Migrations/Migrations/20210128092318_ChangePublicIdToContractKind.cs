using Microsoft.EntityFrameworkCore.Migrations;

namespace TariffConstructor.Infrastructure.Migrations.Migrations
{
    public partial class ChangePublicIdToContractKind : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ContractKind_PublicId",
                table: "ContractKind");

            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "ContractKind",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_ContractKind_PublicId",
                table: "ContractKind",
                column: "PublicId",
                unique: true,
                filter: "[PublicId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContractKind_PublicId",
                table: "ContractKind");

            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "ContractKind",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ContractKind_PublicId",
                table: "ContractKind",
                column: "PublicId");
        }
    }
}
