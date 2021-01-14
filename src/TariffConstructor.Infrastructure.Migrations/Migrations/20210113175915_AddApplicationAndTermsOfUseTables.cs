using Microsoft.EntityFrameworkCore.Migrations;

namespace TariffConstructor.Infrastructure.Migrations.Migrations
{
    public partial class AddApplicationAndTermsOfUseTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForApplication");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForTermsOfUse");

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    PublicId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                    table.UniqueConstraint("AK_Application_PublicId", x => x.PublicId);
                });

            migrationBuilder.CreateTable(
                name: "TermsOfUses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    PublicId = table.Column<string>(nullable: false),
                    DocumentName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermsOfUses", x => x.Id);
                    table.UniqueConstraint("AK_TermsOfUses_PublicId", x => x.PublicId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "TermsOfUses");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForApplication");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForTermsOfUse");
        }
    }
}
