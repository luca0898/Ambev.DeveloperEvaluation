using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

public sealed record DeleteCartItemCommand(Guid UserId, Guid ProductId) : IRequest<bool>;
