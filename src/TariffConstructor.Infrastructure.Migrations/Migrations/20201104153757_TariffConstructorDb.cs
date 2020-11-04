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
                name: "AvailableTariffForUpgrade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false),
                    FromTariffId = table.Column<int>(nullable: false),
                    ToTariffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableTariffForUpgrade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false),
                    PublicId = table.Column<string>(maxLength: 68, nullable: false),
                    NomenclatureId = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    ShortName = table.Column<string>(maxLength: 100, nullable: true),
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
                    PublicId = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
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
                    Id = table.Column<int>(nullable: false),
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
                    Id = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false),
                    PublicId = table.Column<string>(maxLength: 100, nullable: true),
                    NomenclatureId = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    IsMultiple = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    KindId = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    AccountingName = table.Column<string>(maxLength: 100, nullable: true)
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
                    Id = table.Column<int>(nullable: false),
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
                name: "TariffPrice",
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
                    table.PrimaryKey("PK_TariffPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TariffPrice_Tariffs_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TariffToContractKindBinding",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
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
                name: "IncludedProductOptionInTariffs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    TariffId = table.Column<int>(nullable: false),
                    ProductOptionId = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncludedProductOptionInTariffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncludedProductOptionInTariffs_ProductOption_ProductOptionId",
                        column: x => x.ProductOptionId,
                        principalTable: "ProductOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncludedProductOptionInTariffs_Tariffs_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOptionTariff",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false),
                    PublicId = table.Column<string>(maxLength: 100, nullable: true),
                    ProductOptionId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOptionTariff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOptionTariff_ProductOption_ProductOptionId",
                        column: x => x.ProductOptionId,
                        principalTable: "ProductOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvailableProductOptionTariffInTariff",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false),
                    TariffId = table.Column<int>(nullable: false),
                    ProductOptionTariffId = table.Column<int>(nullable: false),
                    MaxCount = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableProductOptionTariffInTariff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableProductOptionTariffInTariff_ProductOptionTariff_ProductOptionTariffId",
                        column: x => x.ProductOptionTariffId,
                        principalTable: "ProductOptionTariff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOptionTariffPrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Price_Value = table.Column<decimal>(nullable: true),
                    Price_Currency = table.Column<string>(maxLength: 3, nullable: true),
                    Period_Value = table.Column<int>(nullable: true),
                    Period_Unit = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ProductOptionTariffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOptionTariffPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOptionTariffPrice_ProductOptionTariff_ProductOptionTariffId",
                        column: x => x.ProductOptionTariffId,
                        principalTable: "ProductOptionTariff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableProductOptionTariffInTariff_ProductOptionTariffId",
                table: "AvailableProductOptionTariffInTariff",
                column: "ProductOptionTariffId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableProductOptionTariffInTariff_TenantId",
                table: "AvailableProductOptionTariffInTariff",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableTariffForUpgrade_TenantId",
                table: "AvailableTariffForUpgrade",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_IncludedProductInTariff_ProductId",
                table: "IncludedProductInTariff",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_IncludedProductInTariff_TariffId",
                table: "IncludedProductInTariff",
                column: "TariffId");

            migrationBuilder.CreateIndex(
                name: "IX_IncludedProductOptionInTariffs_ProductOptionId",
                table: "IncludedProductOptionInTariffs",
                column: "ProductOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_IncludedProductOptionInTariffs_TariffId",
                table: "IncludedProductOptionInTariffs",
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
                name: "IX_ProductOption_TenantId",
                table: "ProductOption",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptionKind_TenantId",
                table: "ProductOptionKind",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptionTariff_ProductOptionId",
                table: "ProductOptionTariff",
                column: "ProductOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptionTariff_TenantId",
                table: "ProductOptionTariff",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptionTariffPrice_ProductOptionTariffId",
                table: "ProductOptionTariffPrice",
                column: "ProductOptionTariffId");

            migrationBuilder.CreateIndex(
                name: "IX_TariffAdvancePrice_TariffId",
                table: "TariffAdvancePrice",
                column: "TariffId");

            migrationBuilder.CreateIndex(
                name: "IX_TariffPrice_TariffId",
                table: "TariffPrice",
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
                name: "AvailableProductOptionTariffInTariff");

            migrationBuilder.DropTable(
                name: "AvailableTariffForUpgrade");

            migrationBuilder.DropTable(
                name: "IncludedProductInTariff");

            migrationBuilder.DropTable(
                name: "IncludedProductOptionInTariffs");

            migrationBuilder.DropTable(
                name: "ProductOptionTariffPrice");

            migrationBuilder.DropTable(
                name: "TariffAdvancePrice");

            migrationBuilder.DropTable(
                name: "TariffPrice");

            migrationBuilder.DropTable(
                name: "TariffToContractKindBinding");

            migrationBuilder.DropTable(
                name: "ProductOptionTariff");

            migrationBuilder.DropTable(
                name: "Tariffs");

            migrationBuilder.DropTable(
                name: "ProductOption");

            migrationBuilder.DropTable(
                name: "ProductOptionKind");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForTariffAdvancePrice");
        }
    }
}
