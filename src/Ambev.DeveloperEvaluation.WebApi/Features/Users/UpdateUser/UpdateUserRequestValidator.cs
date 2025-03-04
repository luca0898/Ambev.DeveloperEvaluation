using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Enums;
using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(user => user.Email)
            .SetValidator(new EmailValidator())
            .When(user => !string.IsNullOrWhiteSpace(user.Email));

        RuleFor(user => user.Username)
            .NotEmpty()
            .Length(3, 50)
            .When(user => !string.IsNullOrWhiteSpace(user.Username));

        RuleFor(user => user.Password)
            .SetValidator(new PasswordValidator())
            .When(user => !string.IsNullOrWhiteSpace(user.Password));

        RuleFor(user => user.Phone)
            .Matches(@"^\+?[1-9]\d{1,14}$")
            .When(user => !string.IsNullOrWhiteSpace(user.Phone));

        RuleFor(user => user.Status)
            .NotEqual(UserStatus.Unknown)
            .When(user => user.Status != default);

        RuleFor(user => user.Role)
            .NotEqual(UserRole.None)
            .When(user => user.Role != default);
    }
}