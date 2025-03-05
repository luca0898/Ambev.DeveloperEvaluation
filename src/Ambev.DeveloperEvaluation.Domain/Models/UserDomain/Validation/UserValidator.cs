using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Entities;
using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Validation;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Email).SetValidator(new EmailValidator());

        RuleFor(user => user.Username)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);

        RuleFor(user => user.Password).SetValidator(new PasswordValidator());

        RuleFor(user => user.Phone).Matches(@"^\+[1-9]\d{10,14}$");

        RuleFor(user => user.Status).NotEqual(UserStatus.Unknown);

        RuleFor(user => user.Role).NotEqual(UserRole.None);
    }
}
