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
using System;
using System.Linq;
using System.Reflection;

namespace Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(
                    i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
