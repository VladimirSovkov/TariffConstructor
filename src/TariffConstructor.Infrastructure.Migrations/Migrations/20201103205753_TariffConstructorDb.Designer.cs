﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TariffConstructor.Infrastructure.Data;

namespace TariffConstructor.Infrastructure.Migrations.Migrations
{
    [DbContext(typeof(TariffConstructorContext))]
    [Migration("20201103205753_TariffConstructorDb")]
    partial class TariffConstructorDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.DBSequenceHiLoForTariffAdvancePrice", "'DBSequenceHiLoForTariffAdvancePrice', '', '1', '1', '', '', 'Int32', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TariffConstructor.Domain.ProductAggregate.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("NomenclatureId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasColumnType("nvarchar(68)")
                        .HasMaxLength(68);

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("PublicId");

                    b.HasIndex("TenantId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("TariffConstructor.Domain.ProductOptionAggregate.ProductOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountingName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsMultiple")
                        .HasColumnType("bit");

                    b.Property<int?>("KindId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomenclatureId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KindId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductOption");
                });

            modelBuilder.Entity("TariffConstructor.Domain.ProductOptionKindAggregate.ProductOptionKind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductOptionKind");
                });

            modelBuilder.Entity("TariffConstructor.Domain.TariffAggregate.IncludedProductInTariff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("RelativeWeight")
                        .HasColumnType("int");

                    b.Property<int>("TariffId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("TariffId");

                    b.ToTable("IncludedProductInTariff");
                });

            modelBuilder.Entity("TariffConstructor.Domain.TariffAggregate.IncludedProductOptionInTariff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductOptionId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TariffId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductOptionId");

                    b.HasIndex("TariffId");

                    b.ToTable("IncludedProductOptionInTariff");
                });

            modelBuilder.Entity("TariffConstructor.Domain.TariffAggregate.Tariff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountingName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("AccountingTariffId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("AwaitingPaymentStrategy")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAcceptanceRequired")
                        .HasColumnType("bit");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<bool>("IsGradualFinishAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("SettingsPresetId")
                        .HasColumnType("int");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<int?>("TermsOfUseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("PublicId");

                    b.HasIndex("TenantId");

                    b.ToTable("Tariffs");
                });

            modelBuilder.Entity("TariffConstructor.Domain.TariffAggregate.TariffAdvancePrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "DBSequenceHiLoForTariffAdvancePrice")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int>("TariffId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TariffId");

                    b.ToTable("TariffAdvancePrice");
                });

            modelBuilder.Entity("TariffConstructor.Domain.TariffAggregate.TariffPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int>("TariffId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TariffId");

                    b.ToTable("TariffPrices");
                });

            modelBuilder.Entity("TariffConstructor.Domain.TariffAggregate.TariffToContractKindBinding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContractKindId")
                        .HasColumnType("int");

                    b.Property<int>("TariffId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TariffId");

                    b.ToTable("TariffToContractKindBinding");
                });

            modelBuilder.Entity("TariffConstructor.Domain.ProductOptionAggregate.ProductOption", b =>
                {
                    b.HasOne("TariffConstructor.Domain.ProductOptionKindAggregate.ProductOptionKind", "Kind")
                        .WithMany()
                        .HasForeignKey("KindId");

                    b.HasOne("TariffConstructor.Domain.ProductAggregate.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TariffConstructor.Domain.TariffAggregate.IncludedProductInTariff", b =>
                {
                    b.HasOne("TariffConstructor.Domain.ProductAggregate.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TariffConstructor.Domain.TariffAggregate.Tariff", null)
                        .WithMany("IncludedProducts")
                        .HasForeignKey("TariffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TariffConstructor.Domain.TariffAggregate.IncludedProductOptionInTariff", b =>
                {
                    b.HasOne("TariffConstructor.Domain.ProductOptionAggregate.ProductOption", "ProductOption")
                        .WithMany()
                        .HasForeignKey("ProductOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TariffConstructor.Domain.TariffAggregate.Tariff", "Tariff")
                        .WithMany("IncludedProductOptions")
                        .HasForeignKey("TariffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TariffConstructor.Domain.TariffAggregate.Tariff", b =>
                {
                    b.OwnsOne("TariffConstructor.Domain.TariffAggregate.TariffTestPeriod", "TestPeriod", b1 =>
                        {
                            b1.Property<int>("TariffId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Unit")
                                .HasColumnType("int");

                            b1.Property<int>("Value")
                                .HasColumnType("int");

                            b1.HasKey("TariffId");

                            b1.ToTable("Tariffs");

                            b1.WithOwner()
                                .HasForeignKey("TariffId");
                        });
                });

            modelBuilder.Entity("TariffConstructor.Domain.TariffAggregate.TariffAdvancePrice", b =>
                {
                    b.HasOne("TariffConstructor.Domain.TariffAggregate.Tariff", "Tariff")
                        .WithMany("AdvancePrices")
                        .HasForeignKey("TariffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("TariffConstructor.Domain.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<int>("TariffAdvancePriceId")
                                .HasColumnType("int");

                            b1.Property<string>("Currency")
                                .HasColumnType("nvarchar(3)")
                                .HasMaxLength(3);

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("TariffAdvancePriceId");

                            b1.ToTable("TariffAdvancePrice");

                            b1.WithOwner()
                                .HasForeignKey("TariffAdvancePriceId");
                        });

                    b.OwnsOne("TariffConstructor.Domain.ValueObjects.ProlongationPeriod", "Period", b1 =>
                        {
                            b1.Property<int>("TariffAdvancePriceId")
                                .HasColumnType("int");

                            b1.Property<int>("Unit")
                                .HasColumnType("int");

                            b1.Property<int>("Value")
                                .HasColumnType("int");

                            b1.HasKey("TariffAdvancePriceId");

                            b1.ToTable("TariffAdvancePrice");

                            b1.WithOwner()
                                .HasForeignKey("TariffAdvancePriceId");
                        });
                });

            modelBuilder.Entity("TariffConstructor.Domain.TariffAggregate.TariffPrice", b =>
                {
                    b.HasOne("TariffConstructor.Domain.TariffAggregate.Tariff", null)
                        .WithMany("Prices")
                        .HasForeignKey("TariffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("TariffConstructor.Domain.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<int>("TariffPriceId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Currency")
                                .HasColumnType("nvarchar(3)")
                                .HasMaxLength(3);

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("TariffPriceId");

                            b1.ToTable("TariffPrices");

                            b1.WithOwner()
                                .HasForeignKey("TariffPriceId");
                        });

                    b.OwnsOne("TariffConstructor.Domain.ValueObjects.ProlongationPeriod", "Period", b1 =>
                        {
                            b1.Property<int>("TariffPriceId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Unit")
                                .HasColumnType("int");

                            b1.Property<int>("Value")
                                .HasColumnType("int");

                            b1.HasKey("TariffPriceId");

                            b1.ToTable("TariffPrices");

                            b1.WithOwner()
                                .HasForeignKey("TariffPriceId");
                        });
                });

            modelBuilder.Entity("TariffConstructor.Domain.TariffAggregate.TariffToContractKindBinding", b =>
                {
                    b.HasOne("TariffConstructor.Domain.TariffAggregate.Tariff", null)
                        .WithMany("ContractKindBindings")
                        .HasForeignKey("TariffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
