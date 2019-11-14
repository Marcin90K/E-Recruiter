using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecruitingSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Data.Configurations
{
    public class RecruiterConfiguration : IEntityTypeConfiguration<Recruiter>
    {
        public void Configure(EntityTypeBuilder<Recruiter> builder)
        {
            builder.HasMany(r => r.OwnedJobOffers)
                   .WithOne(jo => jo.Owner);

            builder.HasOne(r => r.Manager)
                   .WithMany(m => m.Recruiters);
        }
    }
}
