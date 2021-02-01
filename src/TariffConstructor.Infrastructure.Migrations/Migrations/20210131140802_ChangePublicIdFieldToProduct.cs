using Microsoft.EntityFrameworkCore.Migrations;

namespace TariffConstructor.Infrastructure.Migrations.Migrations
{
    public partial class ChangePublicIdFieldToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ApplicationSetting_ApplicationId_SettingId",
                table: "ApplicationSetting");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationSetting_ApplicationId_SettingId",
                table: "ApplicationSetting",
                columns: new[] { "ApplicationId", "SettingId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApplicationSetting_ApplicationId_SettingId",
                table: "ApplicationSetting");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ApplicationSetting_ApplicationId_SettingId",
                table: "ApplicationSetting",
                columns: new[] { "ApplicationId", "SettingId" });
        }
    }
}
