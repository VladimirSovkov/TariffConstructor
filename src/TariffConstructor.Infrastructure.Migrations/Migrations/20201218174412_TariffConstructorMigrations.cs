using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TariffConstructor.Infrastructure.Migrations.Migrations
{
    public partial class TariffConstructorMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoFor");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForApplicationSetting");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForApplicationSettingPreset");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForApplicationSettingSet");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForApplicationSettingValue");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForAvailableProductOptionTariffInTariff");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForAvailableTariffForUpgrade");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForBillingSetting");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForBillingSettingPreset");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForBillingSettingSet");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForIncludedProductInTariff");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForIncludedProductOptionInTariff");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForProduct");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForProductOption");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForProductOptionKind");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForProductOptionTariff");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForSetting");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForSettingEnumValue");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForTariff");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForTariffAdvancePrice");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForTariffPrice");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForTariffToContractKindBinding");

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
                name: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsComputing = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingsPreset",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingsPreset", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingsSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingsSet", x => x.Id);
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
                name: "ApplicationSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ApplicationId = table.Column<int>(nullable: false),
                    SettingId = table.Column<int>(nullable: false),
                    DefaultValue = table.Column<string>(maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    PublicId = table.Column<string>(maxLength: 68, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationSetting", x => x.Id);
                    table.UniqueConstraint("AK_ApplicationSetting_ApplicationId_SettingId", x => new { x.ApplicationId, x.SettingId });
                    table.ForeignKey(
                        name: "FK_ApplicationSetting_Setting_SettingId",
                        column: x => x.SettingId,
                        principalTable: "Setting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillingSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    SettingId = table.Column<int>(nullable: false),
                    PublicId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingSetting", x => x.Id);
                    table.UniqueConstraint("AK_BillingSetting_SettingId_PublicId", x => new { x.SettingId, x.PublicId });
                    table.ForeignKey(
                        name: "FK_BillingSetting_Setting_SettingId",
                        column: x => x.SettingId,
                        principalTable: "Setting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SettingEnumValue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    SettingId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingEnumValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingEnumValue_Setting_SettingId",
                        column: x => x.SettingId,
                        principalTable: "Setting",
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
                name: "ApplicationSettingPreset",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    SettingsPresetId = table.Column<int>(nullable: false),
                    ApplicationSettingId = table.Column<int>(nullable: false),
                    Value_DefaultValue = table.Column<string>(nullable: true),
                    Value_MinValue = table.Column<string>(nullable: true),
                    Value_MaxValue = table.Column<string>(nullable: true),
                    IsRequired = table.Column<bool>(nullable: false),
                    IsReadOnly = table.Column<bool>(nullable: false),
                    IsHidden = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationSettingPreset", x => x.Id);
                    table.UniqueConstraint("AK_ApplicationSettingPreset_ApplicationSettingId_SettingsPresetId", x => new { x.ApplicationSettingId, x.SettingsPresetId });
                    table.ForeignKey(
                        name: "FK_ApplicationSettingPreset_ApplicationSetting_ApplicationSettingId",
                        column: x => x.ApplicationSettingId,
                        principalTable: "ApplicationSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationSettingPreset_SettingsPreset_SettingsPresetId",
                        column: x => x.SettingsPresetId,
                        principalTable: "SettingsPreset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationSettingSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ApplicationSettingId = table.Column<int>(nullable: false),
                    SettingsSetId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationSettingSet", x => x.Id);
                    table.UniqueConstraint("AK_ApplicationSettingSet_ApplicationSettingId_SettingsSetId", x => new { x.ApplicationSettingId, x.SettingsSetId });
                    table.ForeignKey(
                        name: "FK_ApplicationSettingSet_ApplicationSetting_ApplicationSettingId",
                        column: x => x.ApplicationSettingId,
                        principalTable: "ApplicationSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationSettingSet_SettingsSet_SettingsSetId",
                        column: x => x.SettingsSetId,
                        principalTable: "SettingsSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationSettingValue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ApplicationSettingId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ApplicationSettingId2 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationSettingValue", x => x.Id);
                    table.UniqueConstraint("AK_ApplicationSettingValue_ApplicationSettingId", x => x.ApplicationSettingId);
                    table.ForeignKey(
                        name: "FK_ApplicationSettingValue_ApplicationSetting_ApplicationSettingId",
                        column: x => x.ApplicationSettingId,
                        principalTable: "ApplicationSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationSettingValue_ApplicationSetting_ApplicationSettingId2",
                        column: x => x.ApplicationSettingId2,
                        principalTable: "ApplicationSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillingSettingPreset",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    SettingsPresetId = table.Column<int>(nullable: false),
                    BillingSettingId = table.Column<int>(nullable: false),
                    Value_DefaultValue = table.Column<string>(nullable: true),
                    Value_MinValue = table.Column<string>(nullable: true),
                    Value_MaxValue = table.Column<string>(nullable: true),
                    IsRequired = table.Column<bool>(nullable: false),
                    IsReadOnly = table.Column<bool>(nullable: false),
                    IsHidden = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingSettingPreset", x => x.Id);
                    table.UniqueConstraint("AK_BillingSettingPreset_BillingSettingId_SettingsPresetId", x => new { x.BillingSettingId, x.SettingsPresetId });
                    table.ForeignKey(
                        name: "FK_BillingSettingPreset_BillingSetting_BillingSettingId",
                        column: x => x.BillingSettingId,
                        principalTable: "BillingSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillingSettingPreset_SettingsPreset_SettingsPresetId",
                        column: x => x.SettingsPresetId,
                        principalTable: "SettingsPreset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillingSettingSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    SettingsSetId = table.Column<int>(nullable: false),
                    BillingSettingId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingSettingSet", x => x.Id);
                    table.UniqueConstraint("AK_BillingSettingSet_SettingsSetId_BillingSettingId", x => new { x.SettingsSetId, x.BillingSettingId });
                    table.ForeignKey(
                        name: "FK_BillingSettingSet_BillingSetting_BillingSettingId",
                        column: x => x.BillingSettingId,
                        principalTable: "BillingSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillingSettingSet_SettingsSet_SettingsSetId",
                        column: x => x.SettingsSetId,
                        principalTable: "SettingsSet",
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
                name: "IX_ApplicationSetting_SettingId",
                table: "ApplicationSetting",
                column: "SettingId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationSettingPreset_SettingsPresetId",
                table: "ApplicationSettingPreset",
                column: "SettingsPresetId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationSettingSet_SettingsSetId",
                table: "ApplicationSettingSet",
                column: "SettingsSetId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationSettingValue_ApplicationSettingId2",
                table: "ApplicationSettingValue",
                column: "ApplicationSettingId2");

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
                name: "IX_BillingSettingPreset_SettingsPresetId",
                table: "BillingSettingPreset",
                column: "SettingsPresetId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingSettingSet_BillingSettingId",
                table: "BillingSettingSet",
                column: "BillingSettingId");

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
                name: "IX_SettingEnumValue_SettingId",
                table: "SettingEnumValue",
                column: "SettingId");

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
                name: "ApplicationSettingPreset");

            migrationBuilder.DropTable(
                name: "ApplicationSettingSet");

            migrationBuilder.DropTable(
                name: "ApplicationSettingValue");

            migrationBuilder.DropTable(
                name: "AvailableProductOptionTariffInTariff");

            migrationBuilder.DropTable(
                name: "AvailableTariffForUpgrade");

            migrationBuilder.DropTable(
                name: "BillingSettingPreset");

            migrationBuilder.DropTable(
                name: "BillingSettingSet");

            migrationBuilder.DropTable(
                name: "IncludedProductInTariff");

            migrationBuilder.DropTable(
                name: "IncludedProductOptionInTariffs");

            migrationBuilder.DropTable(
                name: "ProductOptionTariffPrice");

            migrationBuilder.DropTable(
                name: "SettingEnumValue");

            migrationBuilder.DropTable(
                name: "TariffAdvancePrice");

            migrationBuilder.DropTable(
                name: "TariffPrice");

            migrationBuilder.DropTable(
                name: "TariffToContractKindBinding");

            migrationBuilder.DropTable(
                name: "ApplicationSetting");

            migrationBuilder.DropTable(
                name: "SettingsPreset");

            migrationBuilder.DropTable(
                name: "BillingSetting");

            migrationBuilder.DropTable(
                name: "SettingsSet");

            migrationBuilder.DropTable(
                name: "ProductOptionTariff");

            migrationBuilder.DropTable(
                name: "Tariffs");

            migrationBuilder.DropTable(
                name: "Setting");

            migrationBuilder.DropTable(
                name: "ProductOption");

            migrationBuilder.DropTable(
                name: "ProductOptionKind");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoFor");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForApplicationSetting");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForApplicationSettingPreset");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForApplicationSettingSet");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForApplicationSettingValue");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForAvailableProductOptionTariffInTariff");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForAvailableTariffForUpgrade");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForBillingSetting");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForBillingSettingPreset");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForBillingSettingSet");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForIncludedProductInTariff");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForIncludedProductOptionInTariff");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForProduct");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForProductOption");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForProductOptionKind");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForProductOptionTariff");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForSetting");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForSettingEnumValue");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForTariff");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForTariffAdvancePrice");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForTariffPrice");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForTariffToContractKindBinding");
        }
    }
}
