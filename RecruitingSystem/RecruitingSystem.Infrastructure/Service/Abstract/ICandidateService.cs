using RecruitingSystem.Infrastructure.Models.Candidate;
using RecruitingSystem.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Service.Abstract
{
    public interface ICandidateService
    {
        CandidateDTO GetCandidate(Guid id);
        CollectionWithPaginationMetadata<CandidateDTO> GetCandidates(ResourceParameters resourceParameters);
        CandidateDTO AddCandidate(CandidateForManipulationDTO candidate);
        CandidateDTO UpdateCandidate(CandidateForManipulationDTO candidate, Guid id);
        void DeleteCandidate(Guid id);
        bool CheckIfCandidateExists(Guid id);
    }
}
