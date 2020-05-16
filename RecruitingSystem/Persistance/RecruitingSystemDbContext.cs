using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistance
{
    public class RecruitingSystemDbContext : DbContext, IReqruitingSystemDbContext
    {

        public RecruitingSystemDbContext(DbContextOptions<RecruitingSystemDbContext> options)
            : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateBasicData> CandidateBasicDatas { get; set; }
        public DbSet<CandidateJobOffer> CandidateJobOffers { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<PersonBasicData> PersonBasicDatas { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecruitingSystemDbContext).Assembly);
        }
    }
}
