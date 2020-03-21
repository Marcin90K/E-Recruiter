using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IReqruitingSystemDbContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<Candidate> Candidates { get; set; }
        DbSet<CandidateBasicData> CandidateBasicDatas { get; set; }
        DbSet<CandidateJobOffer> CandidateJobOffers { get; set; }
        DbSet<Education> Educations { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Experience> Experiences { get; set; }
        DbSet<JobOffer> JobOffers { get; set; }
        DbSet<JobPosition> JobPositions { get; set; }
        DbSet<Manager> Managers { get; set; }
        DbSet<PersonBasicData> PersonBasicDatas { get; set; }
        DbSet<Recruiter> Recruiters { get; set; }

        int SaveChanges();
    }
}
