using Microsoft.EntityFrameworkCore.Migrations;

namespace TariffConstructor.Infrastructure.Migrations.Migrations
{
    public partial class AddContractKindFieldToContractKindBinding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TariffToContractKindBinding_ContractKindId",
                table: "TariffToContractKindBinding",
                column: "ContractKindId");

            migrationBuilder.AddForeignKey(
                name: "FK_TariffToContractKindBinding_ContractKind_ContractKindId",
                table: "TariffToContractKindBinding",
                column: "ContractKindId",
                principalTable: "ContractKind",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TariffToContractKindBinding_ContractKind_ContractKindId",
                table: "TariffToContractKindBinding");

            migrationBuilder.DropIndex(
                name: "IX_TariffToContractKindBinding_ContractKindId",
                table: "TariffToContractKindBinding");
        }
    }
}
