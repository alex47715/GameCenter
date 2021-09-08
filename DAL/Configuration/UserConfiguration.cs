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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasMany(x => x.Cart).WithOne(x => x.User).IsRequired();
            builder.Property(x => x.Role).HasDefaultValue(Role.User).IsRequired();
        }
    }
}
