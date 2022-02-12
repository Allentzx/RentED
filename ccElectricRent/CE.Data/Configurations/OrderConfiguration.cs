using CE.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.OrderId);
            builder.Property(x => x.OrderId).UseIdentityColumn();
            builder.Property(x => x.TotalPrice).IsRequired();
            builder.Property(x => x.CreateDate).HasColumnType("date");
            builder.HasOne(x => x.Voucher).WithMany(x => x.Orders).HasForeignKey(x => x.VoucherId);
            builder.HasOne(x => x.AppUser).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);
        }
    }
}
