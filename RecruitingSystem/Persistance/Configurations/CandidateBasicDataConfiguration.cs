using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class CandidateBasicDataConfiguration : IEntityTypeConfiguration<CandidateBasicData>
    {
        public void Configure(EntityTypeBuilder<CandidateBasicData> builder)
        {
            builder.HasOne(c => c.Address)
                   .WithMany()
                   .IsRequired();

            builder.HasOne(c => c.Candidate)
                   .WithOne(c => c.BasicData);
        }
    }
}
