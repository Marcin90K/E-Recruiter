using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecruitingSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(e => e.PersonBasicData);
        }
    }
}
