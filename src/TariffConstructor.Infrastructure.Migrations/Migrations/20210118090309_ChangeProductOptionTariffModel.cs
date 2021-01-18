using Microsoft.EntityFrameworkCore.Migrations;

namespace TariffConstructor.Infrastructure.Migrations.Migrations
{
    public partial class ChangeProductOptionTariffModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForProductOptionTariffPrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForProductOptionTariffPrice");
        }
    }
}
