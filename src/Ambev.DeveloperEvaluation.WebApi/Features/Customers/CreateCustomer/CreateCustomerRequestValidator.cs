using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;

public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerRequestValidator()
    {
        RuleFor(customer => customer.UserId).NotEmpty();

        RuleFor(customer => customer.ExternalId)
            .NotEmpty()
            .NotNull()
            .NotEqual(0.ToString())
            .NotEqual(Guid.Empty.ToString())
            .Length(1, 50);
    }
}
