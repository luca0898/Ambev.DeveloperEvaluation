using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;

public sealed record CreateCustomerCommand(CreateUserCommand UserCommand, string Name, string ExternalId) : IRequest<CreateCustomerResult>
{
    public ValidationResultDetail Validate()
    {
        var validator = new CreateCustomerCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail { IsValid = result.IsValid, Errors = result.Errors.Select(o => (ValidationErrorDetail)o) };
    }
}
