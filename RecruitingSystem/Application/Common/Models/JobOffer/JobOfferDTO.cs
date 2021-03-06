﻿using Application.Common.Mapping;
using Application.Common.Models.JobPosition;
using Application.Common.Models.Recruiter;
using System;
using System.Collections.Generic;
using Domain.Entities;
using System.Linq;

namespace Application.Common.Models.JobOffer
{
    public class JobOfferDTO : IMapFrom<Domain.Entities.JobOffer>
    {
        public Guid Id { get; set; }

        public JobPositionDTO JobPosition { get; set; }

        public string Description { get; set; }

        public DateTime DateOfAdding { get; set; }

        public DateTime DateOfExpiration { get; set; }

        public string Requirements { get; set; }

        public RecruiterDTO Owner { get; set; }

        public ICollection<Guid> CandidateIds { get; set; } = new List<Guid>();

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Domain.Entities.JobOffer, JobOfferDTO>()
                .ForMember(dest => dest.CandidateIds, opt => opt.MapFrom(src => src.CandidateJobOffers.Select(
                    cj => cj.CandidateId)));
        }
    }
}
