using Microsoft.EntityFrameworkCore.Migrations;

namespace TariffConstructor.Infrastructure.Migrations.Migrations
{
    public partial class ChangePublicIdToTermsOfUse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_TermsOfUses_PublicId",
                table: "TermsOfUses");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Application_PublicId",
                table: "Application");

            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "TermsOfUses",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "Application",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_TermsOfUses_PublicId",
                table: "TermsOfUses",
                column: "PublicId",
                unique: true,
                filter: "[PublicId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Application_PublicId",
                table: "Application",
                column: "PublicId",
                unique: true,
                filter: "[PublicId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TermsOfUses_PublicId",
                table: "TermsOfUses");

            migrationBuilder.DropIndex(
                name: "IX_Application_PublicId",
                table: "Application");

            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "TermsOfUses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "Application",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_TermsOfUses_PublicId",
                table: "TermsOfUses",
                column: "PublicId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Application_PublicId",
                table: "Application",
                column: "PublicId");
        }
    }
}
