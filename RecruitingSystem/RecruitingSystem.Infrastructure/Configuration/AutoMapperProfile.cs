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
            CreateMap<AddressForCreationDTO, Address>();

            CreateMap<Candidate, CanditateDTO>();
            CreateMap<CandidateForCreationDTO, Candidate>();

            CreateMap<CandidateBasicData, CandidateBasicDataDTO>();
            CreateMap<CandidateBasicDataForCreationDTO, CandidateBasicData>();

            CreateMap<CandidateJobOffer, CandidateJobOfferDTO>();
            CreateMap<CandidateJobOfferForCreationDTO, CandidateJobOffer>();

            CreateMap<Education, EducationDTO>();
            CreateMap<EducationForCreationDTO, Education>();

            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeForCreationDTO, Employee>();

            CreateMap<Experience, ExperienceDTO>();
            CreateMap<ExperienceForCreationDTO, Experience>();

            CreateMap<JobOffer, JobOfferDTO>();
            CreateMap<JobOfferForCreationDTO, JobOffer>();

            CreateMap<JobPosition, JobPositionDTO>();
            CreateMap<JobPositionForCreationDTO, JobPosition>();

            CreateMap<Manager, ManagerDTO>();
            CreateMap<ManagerForCreationDTO, Manager>();

            CreateMap<PersonBasicData, PersonBasicDataDTO>();
            CreateMap<PersonBasicDataForCreationDTO, PersonBasicData>();

            CreateMap<Recruiter, RecruiterDTO>();
            CreateMap<RecruiterForCreationDTO, Recruiter>();
        }
    }
}
