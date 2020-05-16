using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.Property(e => e.CompanyName).IsRequired();
            builder.Property(e => e.StartDate).IsRequired();
            builder.Property(e => e.EndDate).IsRequired();
            builder.Property(e => e.JobTitle).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Duties).IsRequired().HasMaxLength(200);

            builder.HasOne(e => e.Candidate)
                   .WithMany(c => c.Experiences)
                   .HasForeignKey(e => e.CandidateId);
        }
    }
}
