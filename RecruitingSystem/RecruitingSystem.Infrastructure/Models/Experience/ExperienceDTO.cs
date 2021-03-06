﻿using RecruitingSystem.Infrastructure.Models.Candidate;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.Experience
{
    public class ExperienceDTO
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string JobTitle { get; set; }
        public string Duties { get; set; }
        public Guid CandidateId { get; set; }
    }
}
