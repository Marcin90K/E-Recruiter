using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.JobOffers.Commands.UpdateJobOffer
{
    public class UpdateJobOfferCommandValidator : AbstractValidator<UpdateJobOfferCommand>
    {
        public UpdateJobOfferCommandValidator()
        {
            RuleFor(j => j.Description).MaximumLength(1000);
            RuleFor(j => j.Requirements).MaximumLength(1000);
            RuleFor(j => j.JobPositionId).NotEmpty();
            RuleFor(j => j.OwnerId).NotEmpty();
        }
    }
}
