using Application.Common.Models.JobPosition;
using System;

namespace Application.Common.Models.JobOffer
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
