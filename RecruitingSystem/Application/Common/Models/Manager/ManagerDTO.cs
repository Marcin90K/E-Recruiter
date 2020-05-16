using Application.Common.Mapping;
using Application.Common.Models.Employee;
using Application.Common.Models.Recruiter;
using Common.Enums;
using System;
using System.Collections.Generic;

namespace Application.Common.Models.Manager
{
    public class ManagerDTO : IMapFrom<Domain.Entities.Manager>
    {
        public Guid Id { get; set; }
        public EmployeeDTO Employee { get; set; }
        public Department Department { get; set; }
        public ICollection<RecruiterDTO> Recruiters { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Domain.Entities.Manager, ManagerDTO>();
        }
    }
}
