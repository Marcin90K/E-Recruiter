using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecruitingSystem.Data.Entities
{
    public class JobPosition : Entity
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
