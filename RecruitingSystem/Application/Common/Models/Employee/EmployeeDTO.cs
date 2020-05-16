using Application.Common.Mapping;
using Application.Common.Models.PersonBasicData;
using System;

namespace Application.Common.Models.Employee
{
    public class EmployeeDTO : IMapFrom<Domain.Entities.Employee>
    {
        public Guid Id { get; set; }
        public string EmployeeCompanyId { get; set; }
        public PersonBasicDataDTO PersonBasicData { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Domain.Entities.Employee, EmployeeDTO>();
        }
    }
}
