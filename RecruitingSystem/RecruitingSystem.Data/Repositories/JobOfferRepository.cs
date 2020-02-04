using Microsoft.EntityFrameworkCore;
using RecruitingSystem.Data.Contexts;
using RecruitingSystem.Data.Entities;
using RecruitingSystem.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RecruitingSystem.Data.Repositories
{
    public class JobOfferRepository : Repository<JobOffer>, IJobOfferRepository
    {
        public JobOfferRepository(AppDbContext context) : base(context)
        {
        }

        public JobOffer GetJobOfferWithFullData(Guid id)
        {
            return _context.Set<JobOffer>().Where(j => j.Id == id).Include(j => j.JobPosition)
                                                                  .Include(j => j.Owner)
                                                                  .FirstOrDefault();
        }

        public IQueryable<JobOffer> GetAllJobOffersWithFullData()
        {
            return _context.Set<JobOffer>().Include(j => j.JobPosition)
                                           .Include(j => j.Owner);
        }
    }
}
