using Application.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models.Address
{
    public class AddressForUpdateDTO : IMapFrom<Domain.Entities.Address>
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int BuildingNumber { get; set; }
        public int? FlatNumber { get; set; }
        public string Zip { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<AddressForUpdateDTO, Domain.Entities.Address>();
        }
    }
}
