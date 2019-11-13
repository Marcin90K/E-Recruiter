using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Data.Entities
{
    public class Entity
    {
        public Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
