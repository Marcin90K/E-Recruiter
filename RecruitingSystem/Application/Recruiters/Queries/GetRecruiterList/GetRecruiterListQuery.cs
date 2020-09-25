using Application.Common.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Recruiters.Queries.GetRecruiterList
{
    public class GetRecruiterListQuery : IRequest<RecruiterListVm>
    {
        public ResourceParameters ResourceParameters { get; set; }
    }
}
