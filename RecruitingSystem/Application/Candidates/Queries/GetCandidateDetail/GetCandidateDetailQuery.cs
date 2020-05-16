using Application.Common.Models.Candidate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Candidates.Queries.GetCandidateDetail
{
    public class GetCandidateDetailQuery : IRequest<CandidateDTO>
    {
        public Guid Id { get; set; }
    }
}
