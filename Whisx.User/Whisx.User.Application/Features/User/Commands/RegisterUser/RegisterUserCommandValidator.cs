using FluentValidation;

namespace Whisx.User.Application.Features.User.Commands.RegisterUser;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Surname)
            .NotEmpty()
            .WithMessage("Surname cannot be empty")
            .WithErrorCode("400")
            .Length(2, 20)
            .WithMessage("Surname cannot be less than 2 and more than 20 characters")
            .WithErrorCode("400");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name cannot be empty")
            .WithErrorCode("400")
            .Length(2, 20)
            .WithMessage("Name cannot be less than 2 and more than 20 characters")
            .WithErrorCode("400");

        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username cannot be empty")
            .WithErrorCode("400")
            .Length(5, 20)
            .WithMessage("Username cannot be less than 5 and more than 20 characters")
            .WithErrorCode("400");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email cannot be empty")
            .WithErrorCode("400")
            .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
            .WithMessage("Email format is invalid")
            .WithErrorCode("400");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password cannot be empty")
            .WithErrorCode("400")
            .Length(5, 20)
            .WithMessage("Password cannot be less than 5 and more than 20 characters")
            .WithErrorCode("400");

        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password)
            .WithMessage("Passwords do not match")
            .WithErrorCode("400");

        RuleFor(x => x.Birthday)
            .LessThan(DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage("Birthday must be less than the current date")
            .WithErrorCode("400");
    }
}