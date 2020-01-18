using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Service.Abstract
{
    public interface IExperienceService
    {
        int GetAmountOfOveralExperienceYears(Guid candidateId);
        int GetAmountOfLastJobYears(Guid candidateId);
    }
}
