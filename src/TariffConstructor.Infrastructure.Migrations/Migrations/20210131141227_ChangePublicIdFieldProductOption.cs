using Microsoft.EntityFrameworkCore.Migrations;

namespace TariffConstructor.Infrastructure.Migrations.Migrations
{
    public partial class ChangePublicIdFieldProductOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Product_PublicId",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "ProductOption",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "Product",
                maxLength: 68,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(68)",
                oldMaxLength: 68);

            migrationBuilder.CreateIndex(
                name: "IX_ProductOption_PublicId",
                table: "ProductOption",
                column: "PublicId",
                unique: true,
                filter: "[PublicId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Product_PublicId",
                table: "Product",
                column: "PublicId",
                unique: true,
                filter: "[PublicId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductOption_PublicId",
                table: "ProductOption");

            migrationBuilder.DropIndex(
                name: "IX_Product_PublicId",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "ProductOption",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "Product",
                type: "nvarchar(68)",
                maxLength: 68,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 68,
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Product_PublicId",
                table: "Product",
                column: "PublicId");
        }
    }
}
