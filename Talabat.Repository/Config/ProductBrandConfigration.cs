﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talabat.Core.Entities;

namespace Talabat.Repository.Config
{
    internal class ProductBrandConfigration : IEntityTypeConfiguration<ProductBrand>
    {


        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.Property(b => b.Name)
                .IsRequired();
        }
    }
}
