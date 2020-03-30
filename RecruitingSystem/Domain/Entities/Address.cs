using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Address : Entity
    {
        public string City { get; set; }

        public string Street { get; set; }

        public int BuildingNumber { get; set; }

        public int? FlatNumber { get; set; }

        public string Zip { get; set; }
    }
}
