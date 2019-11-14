using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecruitingSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Data.Configurations
{
    public class CandidateBasicDataConfiguration : IEntityTypeConfiguration<CandidateBasicData>
    {
        public void Configure(EntityTypeBuilder<CandidateBasicData> builder)
        {
            builder.HasOne(c => c.PersonBasicData);

            builder.HasOne(c => c.Address);

            builder.HasOne(c => c.Candidate)
                   .WithOne(c => c.BasicData);
        }
    }
}
