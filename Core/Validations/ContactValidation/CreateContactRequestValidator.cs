using ContactManagement.Api.Core.Dtos;
using ContactManagement.Api.Core.Entities;
using FluentValidation;

namespace ContactManagement.Api.Core.Validations.ContactValidation;

public class CreateContactRequestValidator: AbstractValidator<ContactDto>
{
    public CreateContactRequestValidator()
    {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                    .WithMessage("First name is required.")
                .MaximumLength(50)
                    .WithMessage("First name cannot exceed 50 characters.")
                .MinimumLength(2)
                    .WithMessage("First name must be at least 2 characters long.");

           RuleFor(x => x.LastName)
                .NotEmpty()
                    .WithMessage("Last name is required.")
                .MaximumLength(50)
                    .WithMessage("Last name cannot exceed 50 characters.")
                .MinimumLength(2)
                    .WithMessage("Last name must be at least 2 characters long.");

    }
}
