using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomerByUserId;

public class GetCustomerByUserIdRequestValidator : AbstractValidator<GetCustomerByUserIdRequest>
{
    public GetCustomerByUserIdRequestValidator()
    {
        RuleFor(customer => customer.UserId).NotEmpty();
    }
}
