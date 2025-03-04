using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomerByUserId;

public class GetCustomerByUserIdCommandValidator : AbstractValidator<GetCustomerByUserIdCommand>
{
    public GetCustomerByUserIdCommandValidator()
    {
        RuleFor(customer => customer.UserId).NotEmpty();
    }
}
