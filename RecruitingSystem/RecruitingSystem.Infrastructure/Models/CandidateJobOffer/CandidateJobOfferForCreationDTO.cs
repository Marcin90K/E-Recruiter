using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.CandidateJobOffer
{
    class CandidateJobOfferForCreationDTO
    {
        public Guid CandidateId { get; set; }
        public Guid JobOfferId { get; set; }
    }
}
