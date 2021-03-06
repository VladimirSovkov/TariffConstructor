﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.ProductOptionModel;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductOptionModel.Mapping
{
    public class ProductOptionMap : IEntityTypeConfiguration<ProductOption>
    {
        public void Configure(EntityTypeBuilder<ProductOption> builder)
        {
            builder.ToTable("ProductOption");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForTariffAdvancePrice);
            
            builder.HasIndex(x => x.TenantId);

            builder.HasIndex(x => x.PublicId).IsUnique();
            builder.Property(x => x.NomenclatureId).HasMaxLength(100);
            builder.Property(x => x.Name).HasMaxLength(255);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.IsMultiple).IsRequired();


            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Kind).WithMany().HasForeignKey(x => x.KindId);

            builder.Property(x => x.CreationDate).ValueGeneratedOnAdd();

            builder.Property(x => x.AccountingName).HasMaxLength(100);
        }
    }
}
