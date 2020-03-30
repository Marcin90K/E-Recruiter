using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Employee : Entity
    {
        public string EmployeeCompanyId { get; set; }

        public Guid PersonBasicDataId { get; set; }

        public virtual PersonBasicData PersonBasicData { get; set; }
    }
}
