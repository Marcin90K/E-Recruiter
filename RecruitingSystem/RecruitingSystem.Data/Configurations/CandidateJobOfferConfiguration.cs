using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecruitingSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Data.Configurations
{
    public class CandidateJobOfferConfiguration : IEntityTypeConfiguration<CandidateJobOffer>
    {
        public void Configure(EntityTypeBuilder<CandidateJobOffer> builder)
        {
            builder.HasKey(cj => new { cj.CandidateId, cj.JobOfferId });

            builder.HasOne(cj => cj.JobOffer)
                   .WithMany(jo => jo.CandidateJobOffers)
                   .HasForeignKey(cj => cj.JobOfferId);

            builder.HasOne(cj => cj.Candidate)
                   .WithMany(c => c.CandidateJobOffers)
                   .HasForeignKey(cj => cj.CandidateId);
        }
    }
}
