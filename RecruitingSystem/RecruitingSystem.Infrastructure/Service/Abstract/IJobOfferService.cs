using RecruitingSystem.Infrastructure.Models.JobOffer;
using RecruitingSystem.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Service.Abstract
{
    public interface IJobOfferService
    {
        CollectionWithPaginationMetadata<JobOfferDTO> GetJobOffers(ResourceParameters resourceParameters);
        JobOfferDTO GetJobOffer(Guid id);
        JobOfferDTO AddJobOffer(JobOfferForManipulationDTO jobOffer);
        JobOfferDTO UpdateJobOffer(JobOfferForManipulationDTO jobOffer);
        void DeleteJobOffer(Guid id);
        bool CheckIfJobOfferExists(Guid id);
    }
}
