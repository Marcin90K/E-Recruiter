using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class RecruiterConfiguration : IEntityTypeConfiguration<Recruiter>
    {
        public void Configure(EntityTypeBuilder<Recruiter> builder)
        {
            builder.HasMany(r => r.OwnedJobOffers)
                   .WithOne(jo => jo.Owner);

            builder.HasOne(r => r.Manager)
                   .WithMany(m => m.Recruiters)
                   .HasForeignKey(r => r.EmployeeId);
        }
    }
}
