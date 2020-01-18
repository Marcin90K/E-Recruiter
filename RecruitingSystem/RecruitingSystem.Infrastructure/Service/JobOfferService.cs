using AutoMapper;
using RecruitingSystem.Data.Entities;
using RecruitingSystem.Data.Repositories.Abstract;
using RecruitingSystem.Infrastructure.Models.JobOffer;
using RecruitingSystem.Infrastructure.Service.Abstract;
using RecruitingSystem.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecruitingSystem.Infrastructure.Service
{
    public class JobOfferService : IJobOfferService
    {
        private IRepository<JobOffer> _repository;
        private IMapper _mapper;

        public JobOfferService(IRepository<JobOffer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CollectionWithPaginationMetadata<JobOfferDTO> GetJobOffers(ResourceParameters resourceParameters)
        {
            var jobOffersFromRepo = _repository.GetAll();

            if (resourceParameters.SearchQuery != null)
            {
                jobOffersFromRepo = ApplySearch(jobOffersFromRepo, resourceParameters.SearchQuery);
            }

            var pagedJobOffers = new PagedList<JobOffer>(jobOffersFromRepo, resourceParameters.PageNumber, resourceParameters.PageSize);
            var jobOffersToReturn = _mapper.Map<PagedList<JobOfferDTO>>(pagedJobOffers);

            return new CollectionWithPaginationMetadata<JobOfferDTO>(jobOffersToReturn, pagedJobOffers.CreateInfo());
        }

        public JobOfferDTO GetJobOffer(Guid id)
        {
            var jobOffer = _repository.GetSingleById(id);
            JobOfferDTO jobOfferToReturn = _mapper.Map<JobOfferDTO>(jobOffer);
            return jobOfferToReturn;
        }

        public JobOfferDTO AddJobOffer(JobOfferForManipulationDTO jobOffer)
        {
            var jobOfferToAdd = _mapper.Map<JobOffer>(jobOffer);

            _repository.Add(jobOfferToAdd);
            if (!_repository.Save())
            {
                throw new Exception("Adding Job Offer has been failed!");
            }

            return _mapper.Map<JobOfferDTO>(jobOfferToAdd);
        }

        public JobOfferDTO UpdateJobOffer(JobOfferForManipulationDTO jobOffer)
        {
            throw new NotImplementedException();
        }

        public void DeleteJobOffer(Guid id)
        {
            var jobOfferToDelete = _repository.GetSingleById(id);
            if (jobOfferToDelete != null)
            {
                _repository.Delete(jobOfferToDelete);
                if (!_repository.Save())
                {
                    throw new Exception("Deleting job offer failed!");
                }
            }
        }

        private IQueryable<JobOffer> ApplySearch(IQueryable<JobOffer> jobOffers, string searchQuery)
        {
            return jobOffers.Where(j => j.JobPosition.Name.ToLowerInvariant().Contains(searchQuery) ||
                j.Owner.EmployeeId.ToString().ToLowerInvariant().Contains(searchQuery) ||
                j.ReferenceNumber.ToString().Contains(searchQuery) ||
                j.Requirements.ToLowerInvariant().Contains(searchQuery));
        }
    }
}
