using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecruitingSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Data.Configurations
{
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasMany(hrm => hrm.Recruiters)
                   .WithOne(r => r.Manager);
        }
    }
}
