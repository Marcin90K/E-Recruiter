using Application.Common.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Candidates.Queries.GetCandidateList
{
    public class GetCandidateListQuery : IRequest<GetCandidateListVm>
    {
        public ResourceParameters ResourceParameters { get; set; }
    }
}
