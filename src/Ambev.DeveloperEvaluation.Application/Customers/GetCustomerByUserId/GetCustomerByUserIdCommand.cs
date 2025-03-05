using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomerByUserId;

public sealed class GetCustomerByUserIdCommand : IRequest<GetCustomerByUserIdResult>
{
    public Guid UserId { get; set; }
}
