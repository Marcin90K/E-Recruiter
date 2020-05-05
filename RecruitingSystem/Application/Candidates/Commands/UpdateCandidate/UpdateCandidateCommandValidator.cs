using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Candidates.Commands.UpdateCandidate
{
    public class UpdateCandidateCommandValidator : AbstractValidator<UpdateCandidateCommand>
    {
        public UpdateCandidateCommandValidator()
        {
            RuleFor(c => c.EntityId).NotNull();
        }
    }
}
