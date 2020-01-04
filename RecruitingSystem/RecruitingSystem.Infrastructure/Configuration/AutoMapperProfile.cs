using AutoMapper;
using RecruitingSystem.Data.Entities;
using RecruitingSystem.Infrastructure.Models.Address;
using RecruitingSystem.Infrastructure.Models.Candidate;
using RecruitingSystem.Infrastructure.Models.CandidateBasicData;
using RecruitingSystem.Infrastructure.Models.CandidateJobOffer;
using RecruitingSystem.Infrastructure.Models.Education;
using RecruitingSystem.Infrastructure.Models.Employee;
using RecruitingSystem.Infrastructure.Models.Experience;
using RecruitingSystem.Infrastructure.Models.JobOffer;
using RecruitingSystem.Infrastructure.Models.JobPosition;
using RecruitingSystem.Infrastructure.Models.Manager;
using RecruitingSystem.Infrastructure.Models.PersonBasicData;
using RecruitingSystem.Infrastructure.Models.Recruiter;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Address, AddressDTO>();
            CreateMap<AddressForManipulationDTO, Address>();

            CreateMap<Candidate, CandidateDTO>();
            CreateMap<CandidateForManipulationDTO, Candidate>();

            CreateMap<CandidateBasicData, CandidateBasicDataDTO>();
            CreateMap<CandidateBasicDataForManipulationDTO, CandidateBasicData>();

            CreateMap<CandidateJobOffer, CandidateJobOfferDTO>();
            CreateMap<CandidateJobOfferForManipulationDTO, CandidateJobOffer>();

            CreateMap<Education, EducationDTO>();
            CreateMap<EducationForManipulationDTO, Education>();

            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeForManipulationDTO, Employee>();

            CreateMap<Experience, ExperienceDTO>();
            CreateMap<ExperienceForManipulationDTO, Experience>();

            CreateMap<JobOffer, JobOfferDTO>();
            CreateMap<JobOfferForManipulationDTO, JobOffer>();

            CreateMap<JobPosition, JobPositionDTO>();
            CreateMap<JobPositionForManipulationDTO, JobPosition>();

            CreateMap<Manager, ManagerDTO>();
            CreateMap<ManagerForManipulationDTO, Manager>();

            CreateMap<PersonBasicData, PersonBasicDataDTO>();
            CreateMap<PersonBasicDataForManipulationDTO, PersonBasicData>();

            CreateMap<Recruiter, RecruiterDTO>();
            CreateMap<RecruiterForManipulationDTO, Recruiter>();
        }
    }
}
