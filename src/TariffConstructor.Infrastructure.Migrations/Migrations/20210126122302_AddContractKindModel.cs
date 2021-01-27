using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TariffConstructor.Infrastructure.Migrations.Migrations
{
    public partial class AddContractKindModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForContractKind");

            migrationBuilder.CreateTable(
                name: "ContractKind",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    PublicId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractKind", x => x.Id);
                    table.UniqueConstraint("AK_ContractKind_PublicId", x => x.PublicId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractKind");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForContractKind");
        }
    }
}
