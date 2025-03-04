using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public record CreateCartCommand(Guid UserId, List<CreateCartItemDto> Products) : IRequest<CreateCartResult>;

public record CreateCartItemDto(Guid ProductId, int Quantity);

public record CreateCartResponse(Guid Id, Guid UserId, DateTime CreatedAt, List<CreateCartItemDto> Products);
