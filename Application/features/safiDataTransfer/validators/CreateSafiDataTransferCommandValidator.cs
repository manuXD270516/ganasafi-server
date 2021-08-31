using Application.features.safiDataTransfer.commands.createSafiDataTransfer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using static Application.helpers.HelpersValidators;

namespace Application.features.safiDataTransfer.validators
{
    public class CreateSafiDataTransferCommandValidator : AbstractValidator<CreateSafiDataTransferCommand>
    {
        public CreateSafiDataTransferCommandValidator()
        {
            RuleFor(t => t.accountNumber)
                .NotNull().WithMessage(MSG_VALIDATION_FIELD_NOT_EMPTY_OR_NULLEABLE);

            RuleFor(t => t.description)
                .NotEmpty().WithMessage(MSG_VALIDATION_FIELD_NOT_EMPTY_OR_NULLEABLE)
                .MaximumLength(300).WithMessage(MSG_VALIDATION_FIELD_MAX_LENGTH);
            
            RuleFor(t => t.headline)
                .NotEmpty().WithMessage(MSG_VALIDATION_FIELD_MAX_LENGTH)
                .MinimumLength(8).WithMessage(MSG_VALIDATION_FIELD_MIN_LENGTH);
        
        }
    }
}
