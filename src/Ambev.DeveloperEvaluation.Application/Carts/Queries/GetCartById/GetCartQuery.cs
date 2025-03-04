using Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCart;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCartById;

public class GetCartQuery : IRequest<GetCartResult>
{
    public Guid Id { get; set; }
    public GetCartQuery(Guid id)
    {
        Id = id;
    }
}
