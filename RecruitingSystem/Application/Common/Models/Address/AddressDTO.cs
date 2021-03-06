﻿using Application.Common.Mapping;
using System;

namespace Application.Common.Models.Address
{
    public class AddressDTO : IMapFrom<Domain.Entities.Address>
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int BuildingNumber { get; set; }
        public int? FlatNumber { get; set; }
        public string Zip { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Domain.Entities.Address, AddressDTO>();
        }
    }
}
