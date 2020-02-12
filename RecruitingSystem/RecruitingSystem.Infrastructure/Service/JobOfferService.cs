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
        private IJobOfferRepository _jobOfferRepository;
        private IMapper _mapper;

        public JobOfferService(IJobOfferRepository repository, IMapper mapper)
        {
            _jobOfferRepository = repository;
            _mapper = mapper;
        }

        public CollectionWithPaginationMetadata<JobOfferDTO> GetJobOffers(ResourceParameters resourceParameters)
        {
            var jobOffersFromRepo = _jobOfferRepository.GetAllJobOffersWithFullData();

            if (resourceParameters.Search != null)
            {
                jobOffersFromRepo = ApplySearch(jobOffersFromRepo, resourceParameters.Search);
            }

            var pagedJobOffers = new PagedList<JobOffer>(jobOffersFromRepo, resourceParameters.PageNumber, resourceParameters.PageSize);
            var jobOffersToReturn = _mapper.Map<IEnumerable<JobOfferDTO>>(pagedJobOffers);

            return new CollectionWithPaginationMetadata<JobOfferDTO>(jobOffersToReturn, pagedJobOffers.CreateInfo());
        }

        public JobOfferDTO GetJobOffer(Guid id)
        {
            var jobOffer = _jobOfferRepository.GetJobOfferWithFullData(id);
            JobOfferDTO jobOfferToReturn = _mapper.Map<JobOfferDTO>(jobOffer);
            return jobOfferToReturn;
        }

        public JobOfferDTO AddJobOffer(JobOfferForManipulationDTO jobOffer)
        {
            var jobOfferToAdd = _mapper.Map<JobOffer>(jobOffer);
            jobOfferToAdd.DateOfAdding = DateTime.Now;

            _jobOfferRepository.Add(jobOfferToAdd);
            if (!_jobOfferRepository.Save())
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
            var jobOfferToDelete = _jobOfferRepository.GetSingleById(id);
            if (jobOfferToDelete != null)
            {
                _jobOfferRepository.Delete(jobOfferToDelete);
                if (!_jobOfferRepository.Save())
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
