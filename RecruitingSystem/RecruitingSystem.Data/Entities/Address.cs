using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RecruitingSystem.Data.Entities
{
    public class Address : Entity
    {
        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string Street { get; set; }

        public int BuildingNumber { get; set; }

        public int? FlatNumber { get; set; }

        [Required]
        public string Zip { get; set; }
    }
}
