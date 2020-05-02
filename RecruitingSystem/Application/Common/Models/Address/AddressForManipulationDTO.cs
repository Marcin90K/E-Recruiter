using Application.Common.Mapping;

namespace Application.Common.Models.Address
{
    public class AddressForManipulationDTO : IMapFrom<Domain.Entities.Address>
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int BuildingNumber { get; set; }
        public int? FlatNumber { get; set; }
        public string Zip { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<AddressForManipulationDTO, Domain.Entities.Address>();
        }
    }
}
