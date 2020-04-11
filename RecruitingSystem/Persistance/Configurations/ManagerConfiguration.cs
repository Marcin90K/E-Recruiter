using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasMany(m => m.Recruiters)
                   .WithOne(r => r.Manager)
                   .OnDelete(DeleteBehavior.Restrict);
            
                   //.HasForeignKey(m => m.EmployeeId);
        }
    }
}
