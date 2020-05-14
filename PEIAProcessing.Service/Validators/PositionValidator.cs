using System;
using FluentValidation;
using PEIAProcessing.Domain.Entities;

namespace PEIAProcessing.Service.Validators
{
    public class PositionValidator : AbstractValidator<Position>
    {
        public PositionValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(c => c.PositionId)
                .NotEmpty().WithMessage("Is necessary to inform the PositionId.")
                .NotNull().WithMessage("Is necessary to inform the PositionId.");

            RuleFor(c => c.Currency)
                .NotEmpty().WithMessage("Is necessary to inform the Currency.")
                .NotNull().WithMessage("Is necessary to inform the .");

            RuleFor(c => c.Currency)
                .NotEmpty().WithMessage("Is necessary to inform the Currency.")
                .NotNull().WithMessage("Is necessary to inform the Currency.");
        }
    }
}
