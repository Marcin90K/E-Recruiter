using Application.Common.Models.Recruiter;
using Application.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Recruiters.Queries.GetRecruiterList
{
    public class RecruiterListVm
    {
        public IList<RecruiterDTO> Recruiters { get; set; }
        public Pagination Pagination { get; set; }
    }
}
