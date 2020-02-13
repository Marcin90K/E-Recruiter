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
            var candidate = _candidateRepository.GetCandidateWithFullData(id);
            var candidateToReturn = _mapper.Map<CandidateDTO>(candidate);
            return candidateToReturn;
        }

        public CollectionWithPaginationMetadata<CandidateDTO> GetCandidates(ResourceParameters resourceParameters)
        {
            var candidatesFromRepo = _candidateRepository.GetAllCandidatesWithFullData();

            if (resourceParameters.Search != null)
            {
                candidatesFromRepo = ApplySearch(candidatesFromRepo, resourceParameters.Search);
            }

            var pagedCandidates = new PagedList<Candidate>(candidatesFromRepo, resourceParameters.PageNumber, resourceParameters.PageSize);
            var candidatesToReturn = _mapper.Map<IEnumerable<CandidateDTO>>(pagedCandidates);

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

        public bool CheckIfCandidateExists(Guid id)
        {
            return _candidateRepository.IfExists(id);
        }

        private IQueryable<Candidate> ApplySearch(IQueryable<Candidate> candidates, string searchQuery)
        {
            return candidates.Where(c => c.BasicData.PersonBasicData.LastName == searchQuery
                  || c.BasicData.PersonBasicData.FirstName == searchQuery
                  );
        }
    }
}
