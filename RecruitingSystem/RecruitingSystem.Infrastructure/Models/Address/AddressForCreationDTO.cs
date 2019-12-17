using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.Address
{
    public class AddressForCreationDTO
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int BuildingNumber { get; set; }
        public int? FlatNumber { get; set; }
        public string Zip { get; set; }
    }
}
