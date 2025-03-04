using Ambev.DeveloperEvaluation.Domain.Models.CartDomain.Dtos;

namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCart;

public sealed record GetCartResult(
Guid Id,
Guid UserId,
DateTime CreatedAt,
IEnumerable<CartItemDto> Products);
