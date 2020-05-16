using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Configurations
{
    public class PersonBasicDataConfiguration : IEntityTypeConfiguration<PersonBasicData>
    {
        public void Configure(EntityTypeBuilder<PersonBasicData> builder)
        {
            builder.Property(p => p.FirstName).IsRequired();
            builder.Property(p => p.LastName).IsRequired();
            builder.Property(p => p.DateOfBirth).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.PhoneNumber).IsRequired();
        }
    }
}
