using RecruitingSystem.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecruitingSystem.Data.Entities
{
    public class Employee : Entity
    {
        public string EmployeeCompanyId { get; set; }

        public virtual PersonBasicData PersonBasicData { get; set; }

        public EmployeeFunction EmployeeFunction { get; set; }
    }
}
