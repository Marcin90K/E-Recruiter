using Newtonsoft.Json;
using RecruitingSystem.Infrastructure.Models.JobPosition;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.JobOffer
{
    public class JobOfferForManipulationDTO
    {
        public int ReferenceNumber { get; set; }

        public JobPositionForManipulationDTO JobPosition { get; set; }

        public string Description { get; set; }

        public DateTime DateOfExpiration { get; set; }

        public string Requirements { get; set; }

        public Guid OwnerId { get; set; }

    }
}
