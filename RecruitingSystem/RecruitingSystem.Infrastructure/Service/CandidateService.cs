using AutoMapper;
using RecruitingSystem.Data.Entities;
using RecruitingSystem.Data.Repositories.Abstract;
using RecruitingSystem.Infrastructure.Models.Candidate;
using RecruitingSystem.Infrastructure.Service.Abstract;
using RecruitingSystem.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecruitingSystem.Infrastructure.Service
{
    public class CandidateService : ICandidateService
    {
        private ICandidateRepository _candidateRepository;
        private IMapper _mapper;

        public CandidateService(ICandidateRepository repository, IMapper mapper)
        {
            _candidateRepository = repository;
            _mapper = mapper;
        }

        public CandidateDTO GetCandidate(Guid id)
        {
            //var candidate = _repository.GetSingleById(id);
            var candidate = _candidateRepository.GetCandidateWithFullData(id); // GetSingleById(id);
            var candidateToReturn = _mapper.Map<CandidateDTO>(candidate);
            return candidateToReturn;
        }

        public CollectionWithPaginationMetadata<CandidateDTO> GetCandidates(ResourceParameters resourceParameters)
        {
            var candidatesAFromRepo = _candidateRepository.GetAllCandidatesWithFullData();

            if (resourceParameters.SearchQuery != null)
            {
                candidatesAFromRepo = ApplySearch(candidatesAFromRepo, resourceParameters.SearchQuery);
            }

            var pagedCandidates = new PagedList<Candidate>(candidatesAFromRepo, resourceParameters.PageNumber, resourceParameters.PageSize);
            var candidatesToReturn = _mapper.Map<PagedList<CandidateDTO>>(pagedCandidates);

            return new CollectionWithPaginationMetadata<CandidateDTO>(candidatesToReturn, pagedCandidates.CreateInfo());

        }

        public CandidateDTO AddCandidate(CandidateForManipulationDTO candidate)
        {
            var candidateToAdd = _mapper.Map<Candidate>(candidate);

            _candidateRepository.Add(candidateToAdd);
            if (!_candidateRepository.Save())
            {
                throw new Exception("Adding Candidate has been failed!");
            }

            return _mapper.Map<CandidateDTO>(candidateToAdd);
        }

        public void DeleteCandidate(Guid id)
        {
            var candidateToDelete = _candidateRepository.GetSingleById(id);
            if (candidateToDelete != null)
            {
                _candidateRepository.Delete(candidateToDelete);
                if (!_candidateRepository.Save())
                {
                    throw new Exception("Candidate deleting has been failed!");
                }
            }
        }

        private IQueryable<Candidate> ApplySearch(IQueryable<Candidate> candidates, string searchQuery)
        {
            return candidates.Where(c => c.ExpectedSalary == Int32.Parse(searchQuery)
                  || c.BasicData.PersonBasicData.LastName == searchQuery
                  || c.BasicData.PersonBasicData.FirstName == searchQuery
                  );
        }
    }
}
