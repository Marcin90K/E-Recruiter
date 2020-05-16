using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Candidates.Commands.CreateCandidate
{
    public class CreateCandidateCommandValidator : AbstractValidator<CreateCandidateCommand>
    {
        public CreateCandidateCommandValidator()
        {
            RuleFor(c => c.ExpectedSalary).GreaterThan(0);
            RuleFor(c => c.CandidateBasicData.Address.BuildingNumber).GreaterThan(0);
            RuleFor(c => c.CandidateBasicData.Address.FlatNumber).GreaterThan(0);
            RuleFor(c => c.CandidateBasicData.Address.City).MaximumLength(50);
            RuleFor(c => c.CandidateBasicData.Address.Street).MaximumLength(100);
            RuleFor(c => c.Educations).NotNull();
        }
    }
}
