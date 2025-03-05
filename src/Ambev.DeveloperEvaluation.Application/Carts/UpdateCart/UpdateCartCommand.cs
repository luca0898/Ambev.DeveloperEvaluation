using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.UpdateCart;

public record UpdateCartCommand(Guid Id, Guid UserId, List<UpdateCartProductDto> Products) : IRequest<UpdateCartResult?>;
