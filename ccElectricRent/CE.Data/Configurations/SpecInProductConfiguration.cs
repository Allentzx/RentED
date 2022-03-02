using CE.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Configurations
{
   public class SpecInProductConfiguration : IEntityTypeConfiguration<SpecInProduct>
    {
        public void Configure(EntityTypeBuilder<SpecInProduct> builder)
        {
            builder.ToTable("SpecInProducts");
            builder.HasKey(x => new { x.ProductId, x.SpecId });
            builder.HasOne(x => x.Product).WithMany(x => x.SpecInProducts).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Specific).WithMany(x => x.SpecInProducts).HasForeignKey(x => x.SpecId);
        }
    }
}
