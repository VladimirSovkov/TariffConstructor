using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TariffConstructor.Infrastructure.Migrations.Migrations
{
    public partial class TariffConstructorDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForTariffAdvancePrice");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: false),
                    PublicId = table.Column<string>(maxLength: 68, nullable: false),
                    NomenclatureId = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    ShortName = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.UniqueConstraint("AK_Product_PublicId", x => x.PublicId);
                });

            migrationBuilder.CreateTable(
                name: "ProductOptionKind",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: false),
                    PublicId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOptionKind", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tariffs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: false),
                    PublicId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false),
                    TestPeriod_Value = table.Column<int>(nullable: true),
                    TestPeriod_Unit = table.Column<int>(nullable: true),
                    AccountingName = table.Column<string>(maxLength: 100, nullable: true),
                    PaymentType = table.Column<int>(nullable: false),
                    AwaitingPaymentStrategy = table.Column<string>(maxLength: 100, nullable: true),
                    AccountingTariffId = table.Column<string>(maxLength: 100, nullable: true),
                    SettingsPresetId = table.Column<int>(nullable: true),
                    TermsOfUseId = table.Column<int>(nullable: true),
                    IsAcceptanceRequired = table.Column<bool>(nullable: false),
                    IsGradualFinishAvailable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tariffs", x => x.Id);
                    table.UniqueConstraint("AK_Tariffs_PublicId", x => x.PublicId);
                });

            migrationBuilder.CreateTable(
                name: "ProductOption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: false),
                    PublicId = table.Column<string>(nullable: true),
                    NomenclatureId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IsMultiple = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    KindId = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    AccountingName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOption_ProductOptionKind_KindId",
                        column: x => x.KindId,
                        principalTable: "ProductOptionKind",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductOption_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncludedProductInTariff",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TariffId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    RelativeWeight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncludedProductInTariff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncludedProductInTariff_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncludedProductInTariff_Tariffs_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TariffAdvancePrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Price_Value = table.Column<decimal>(nullable: true),
                    Price_Currency = table.Column<string>(maxLength: 3, nullable: true),
                    Period_Value = table.Column<int>(nullable: true),
                    Period_Unit = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    TariffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffAdvancePrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TariffAdvancePrice_Tariffs_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TariffPrices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price_Value = table.Column<decimal>(nullable: true),
                    Price_Currency = table.Column<string>(maxLength: 3, nullable: true),
                    Period_Value = table.Column<int>(nullable: true),
                    Period_Unit = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    TariffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TariffPrices_Tariffs_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TariffToContractKindBinding",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TariffId = table.Column<int>(nullable: false),
                    ContractKindId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffToContractKindBinding", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TariffToContractKindBinding_Tariffs_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncludedProductOptionInTariff",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    TariffId = table.Column<int>(nullable: false),
                    ProductOptionId = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncludedProductOptionInTariff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncludedProductOptionInTariff_ProductOption_ProductOptionId",
                        column: x => x.ProductOptionId,
                        principalTable: "ProductOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncludedProductOptionInTariff_Tariffs_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncludedProductInTariff_ProductId",
                table: "IncludedProductInTariff",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_IncludedProductInTariff_TariffId",
                table: "IncludedProductInTariff",
                column: "TariffId");

            migrationBuilder.CreateIndex(
                name: "IX_IncludedProductOptionInTariff_ProductOptionId",
                table: "IncludedProductOptionInTariff",
                column: "ProductOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_IncludedProductOptionInTariff_TariffId",
                table: "IncludedProductOptionInTariff",
                column: "TariffId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_TenantId",
                table: "Product",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOption_KindId",
                table: "ProductOption",
                column: "KindId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOption_ProductId",
                table: "ProductOption",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TariffAdvancePrice_TariffId",
                table: "TariffAdvancePrice",
                column: "TariffId");

            migrationBuilder.CreateIndex(
                name: "IX_TariffPrices_TariffId",
                table: "TariffPrices",
                column: "TariffId");

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_TenantId",
                table: "Tariffs",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_TariffToContractKindBinding_TariffId",
                table: "TariffToContractKindBinding",
                column: "TariffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncludedProductInTariff");

            migrationBuilder.DropTable(
                name: "IncludedProductOptionInTariff");

            migrationBuilder.DropTable(
                name: "TariffAdvancePrice");

            migrationBuilder.DropTable(
                name: "TariffPrices");

            migrationBuilder.DropTable(
                name: "TariffToContractKindBinding");

            migrationBuilder.DropTable(
                name: "ProductOption");

            migrationBuilder.DropTable(
                name: "Tariffs");

            migrationBuilder.DropTable(
                name: "ProductOptionKind");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForTariffAdvancePrice");
        }
    }
}
