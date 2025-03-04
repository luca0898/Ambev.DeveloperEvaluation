using FluentValidation;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Validation;

public class EmailValidator : AbstractValidator<string>
{
    public EmailValidator()
    {
        RuleFor(email => email).NotEmpty().MaximumLength(100).Must(BeValidEmail);
    }

    private bool BeValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) return false;

        return new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").IsMatch(email);
    }
}
