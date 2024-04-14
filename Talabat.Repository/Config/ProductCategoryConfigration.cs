using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talabat.Core.Entities;

namespace Talabat.Repository.Config
{
    internal class ProductCategoryConfigration : IEntityTypeConfiguration<ProductCategory>
    {


        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired();
        }
    }
}
