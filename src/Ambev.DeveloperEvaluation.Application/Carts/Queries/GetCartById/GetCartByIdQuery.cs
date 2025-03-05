using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCartById;

public record GetCartByIdQuery : IRequest<GetCartByIdResponse>
{
    public Guid Id { get; set; }
}

public record GetCartByIdResponse(Guid Id, Guid UserId, DateTime CreatedAt, List<CreateCartItemDto> Products);
