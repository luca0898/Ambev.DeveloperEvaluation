using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class AddOrUpdateCartItemCommand : IRequest<CreateOrUpdateCartResult>
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
