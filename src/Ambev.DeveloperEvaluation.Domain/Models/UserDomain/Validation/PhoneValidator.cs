using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Validation;

public class PhoneValidator : AbstractValidator<string>
{
    public PhoneValidator()
    {
        RuleFor(phone => phone).NotEmpty().Matches(@"^\+?[1-9]\d{1,14}$");
    }
}
