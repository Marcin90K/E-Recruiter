﻿using RecruitingSystem.Infrastructure.Models.Candidate;
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
        void DeleteCandidate(Guid id);
    }
}
