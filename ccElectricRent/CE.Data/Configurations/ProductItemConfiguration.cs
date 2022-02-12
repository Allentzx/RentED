using CE.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Configurations
{
    public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.ToTable("ProductItems");
            builder.HasKey(x => new { x.PrlItemId, x.ProductId });
            builder.Property(x => x.ProductId).UseIdentityColumn();
            builder.HasOne(x => x.Product).WithMany(x => x.ProductItems).HasForeignKey(x => x.PrlItemId);
        }
    }
}
