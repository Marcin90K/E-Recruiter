using Application.Common.Models.Recruiter;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Recruiters.Queries.GetRecruiterDetail
{
    public class GetRecruiterDetailQuery : IRequest<RecruiterDTO>
    {
        public Guid Id { get; set; }
    }
}
