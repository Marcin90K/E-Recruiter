using RecruitingSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecruitingSystem.Data.Repositories.Abstract
{
    public interface ICandidateRepository : IRepository<Candidate>
    {
        Candidate GetCandidateWithFullData(Guid id);
        IQueryable<Candidate> GetAllCandidatesWithFullData();
    }
}
