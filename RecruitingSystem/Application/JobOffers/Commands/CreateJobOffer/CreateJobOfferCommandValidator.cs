using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.JobOffers.Commands.CreateJobOffer
{
    public class CreateJobOfferCommandValidator : AbstractValidator<CreateJobOfferCommand>
    {
        public CreateJobOfferCommandValidator()
        {
            RuleFor(j => j.Description).MaximumLength(1000);
            RuleFor(j => j.Requirements).MaximumLength(1000);
        }
    }
}
