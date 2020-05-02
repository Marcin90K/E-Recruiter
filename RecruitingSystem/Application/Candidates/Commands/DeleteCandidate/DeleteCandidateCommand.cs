using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Candidates.Commands.DeleteCandidate
{
    public class DeleteCandidateCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
