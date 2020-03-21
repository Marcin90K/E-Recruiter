using Application.Common.Models.Address;
using Application.Common.Models.Candidate;
using Application.Common.Models.CandidateBasicData;
using Application.Common.Models.CandidateJobOffer;
using Application.Common.Models.Education;
using Application.Common.Models.Employee;
using Application.Common.Models.Experience;
using Application.Common.Models.JobOffer;
using Application.Common.Models.JobPosition;
using Application.Common.Models.Manager;
using Application.Common.Models.PersonBasicData;
using Application.Common.Models.Recruiter;
using AutoMapper;
using Domain.Entities;
using System.Linq;

namespace Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Address, AddressDTO>();
            CreateMap<AddressForManipulationDTO, Address>();

            CreateMap<Candidate, CandidateDTO>()
                .ForMember(dest => dest.CandidateBasicData, opt => opt.MapFrom(src => src.BasicData));
            CreateMap<CandidateForManipulationDTO, Candidate>()
                .ForMember(dest => dest.BasicData, opt => opt.MapFrom(src => src.CandidateBasicData));

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

            CreateMap<JobOffer, JobOfferDTO>()
                .ForMember(dest => dest.CandidateIds, opt => opt.MapFrom(src => src.CandidateJobOffers.Select(c => c.CandidateId)));
            CreateMap<JobOfferForManipulationDTO, JobOffer>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.OwnerId));

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
