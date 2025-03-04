using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(customer => customer.ExternalId)
            .NotEmpty()
            .NotNull()
            .Length(1, 50);
    }
}
