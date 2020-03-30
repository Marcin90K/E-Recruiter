using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Configurations
{
    public class JobOfferConfiguration : IEntityTypeConfiguration<JobOffer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<JobOffer> builder)
        {
            builder.Property(j => j.Description).IsRequired().HasMaxLength(1000);
            builder.Property(j => j.DateOfAdding).IsRequired();
            builder.Property(j => j.DateOfExpiration).IsRequired();
            builder.Property(j => j.Requirements).IsRequired();

            builder.HasOne(j => j.JobPosition);

            builder.HasOne(j => j.Owner)
                   .WithMany(o => o.OwnedJobOffers)
                   .HasForeignKey(j => j.EmployeeId);
        }
    }
}
