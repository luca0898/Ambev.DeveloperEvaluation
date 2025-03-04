using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;

public sealed class CreateCustomerCommand : IRequest<CreateCustomerResult>
{
    public CreateUserCommand UserCommand { get; set; }
    public string Name { get; set; }
    public string ExternalId { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new CreateCustomerCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail { IsValid = result.IsValid, Errors = result.Errors.Select(o => (ValidationErrorDetail)o) };
    }
}
