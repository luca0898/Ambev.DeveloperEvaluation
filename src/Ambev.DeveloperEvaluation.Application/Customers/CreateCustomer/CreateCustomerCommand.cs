using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;

public sealed class CreateCustomerCommand : IRequest<CreateCustomerResult>
{
    public Guid UserId { get; set; }
    public string ExternalId { get; set; } = string.Empty;
}
