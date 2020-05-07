using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasOne(c => c.BasicData)
                   .WithOne(b => b.Candidate);
                   //.HasForeignKey(b => b.)
            //.HasForeignKey(b => b.);

            builder.HasMany(c => c.Educations)
                   .WithOne(e => e.Candidate).HasForeignKey(c => c.CandidateId);

            builder.HasMany(c => c.Experiences)
                   .WithOne(e => e.Candidate).HasForeignKey(e => e.CandidateId);
        }
    }
}
