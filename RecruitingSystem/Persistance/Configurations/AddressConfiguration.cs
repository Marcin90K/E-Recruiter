using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(a => a.City).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Street).IsRequired().HasMaxLength(100);
            builder.Property(a => a.BuildingNumber).IsRequired();
            builder.Property(a => a.Zip).IsRequired();
        }
    }
}
