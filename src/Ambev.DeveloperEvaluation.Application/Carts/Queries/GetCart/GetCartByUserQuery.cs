using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCart;

public sealed record GetCartByUserQuery(Guid UserId) : IRequest<GetCartResult>;
