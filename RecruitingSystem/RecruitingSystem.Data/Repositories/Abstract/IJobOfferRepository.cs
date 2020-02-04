using RecruitingSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecruitingSystem.Data.Repositories.Abstract
{
    public interface IJobOfferRepository : IRepository<JobOffer>
    {
        JobOffer GetJobOfferWithFullData(Guid id);
        IQueryable<JobOffer> GetAllJobOffersWithFullData();
    }
}
