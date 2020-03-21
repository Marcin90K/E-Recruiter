using System;

namespace Application.Common.Models.PersonBasicData
{
    public class PersonBasicDataForManipulationDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}
