using Microsoft.EntityFrameworkCore;
using RecruitingSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Data.Configurations
{
    public class JobOfferConfiguration : IEntityTypeConfiguration<JobOffer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<JobOffer> builder)
        {
            builder.HasOne(jo => jo.JobPosition);

            builder.HasOne(jo => jo.Owner)
                   .WithMany(o => o.OwnedJobOffers);
        }
    }
}
