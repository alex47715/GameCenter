using GameCenter.DAL.Entities;
using GameCenter.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.DAL.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasOne(x => x.Product).WithOne(x => x.Order).IsRequired();
            builder.HasOne(x => x.User).WithMany(p => p.Cart).IsRequired();
            builder.Property(b => b.Status).HasDefaultValue(ParcelStatus.UnPaid).IsRequired();
        }
    }
}
