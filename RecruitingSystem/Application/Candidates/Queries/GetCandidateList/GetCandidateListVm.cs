using Application.Common.Models.Candidate;
using Application.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Candidates.Queries.GetCandidateList
{
    public class GetCandidateListVm
    {
        public IList<CandidateDTO> Cadidates { get; set; }
        public Pagination Pagination { get; set; }
    }
}
