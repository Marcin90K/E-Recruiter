using Microsoft.EntityFrameworkCore;
using RecruitingSystem.Data.Contexts;
using RecruitingSystem.Data.Entities;
using RecruitingSystem.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace RecruitingSystem.Data.Repositories
{
    public class CandidateRepository : Repository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public Candidate GetCandidateWithFullData(Guid id)
        {
            return _context.Set<Candidate>().Where(c => c.Id == id).Include(c => c.BasicData)
                                                                   .ThenInclude(bd => bd.PersonBasicData)
                                                                   .Include(c => c.BasicData)
                                                                   .ThenInclude(bd => bd.Address)
                                                                   .Include(c => c.CandidateJobOffers)
                                                                   .Include(c => c.Educations)
                                                                   .Include(c => c.Experiences)
                                                                   .FirstOrDefault();
        }

        public IQueryable<Candidate> GetAllCandidatesWithFullData()
        {
            return _context.Set<Candidate>().Include(c => c.BasicData)
                                            .ThenInclude(bd => bd.Address)
                                            .Include(c => c.BasicData)
                                            .ThenInclude(bd => bd.PersonBasicData)
                                            .Include(c => c.CandidateJobOffers)
                                            .Include(c => c.Educations)
                                            .Include(c => c.Experiences);
        }
    }
}