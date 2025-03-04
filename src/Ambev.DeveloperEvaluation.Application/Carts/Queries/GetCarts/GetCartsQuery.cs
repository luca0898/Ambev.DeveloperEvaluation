using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCarts;

public record GetCartsQuery : IRequest<List<GetCartResponse>>;

public record GetCartResponse(Guid Id, Guid UserId, DateTime CreatedAt);
