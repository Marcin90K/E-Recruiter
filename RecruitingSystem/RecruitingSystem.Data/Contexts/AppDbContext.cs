using Microsoft.EntityFrameworkCore;
using RecruitingSystem.Data.Configurations;
using RecruitingSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CandidateBasicDataConfiguration());
            modelBuilder.ApplyConfiguration(new CandidateConfiguration());
            modelBuilder.ApplyConfiguration(new CandidateJobOfferConfiguration());
            modelBuilder.ApplyConfiguration(new EducationConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new ExperienceConfiguration());
            modelBuilder.ApplyConfiguration(new JobOfferConfiguration());
            modelBuilder.ApplyConfiguration(new ManagerConfiguration());
            modelBuilder.ApplyConfiguration(new RecruiterConfiguration());
        }
    }
}
