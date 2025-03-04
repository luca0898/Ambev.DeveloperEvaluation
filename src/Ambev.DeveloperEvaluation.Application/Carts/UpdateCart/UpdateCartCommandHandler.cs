using Ambev.DeveloperEvaluation.Domain.Models.CartDomain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.UpdateCart;

public class UpdateCartCommandHandler(ICartRepository _cartRepository, IMapper _mapper) : IRequestHandler<UpdateCartCommand, UpdateCartResult?>
{
    public async Task<UpdateCartResult> Handle(UpdateCartCommand command, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByIdAsync(command.Id, cancellationToken);
        _ = cart ?? throw new KeyNotFoundException($"Cart with ID {command.Id} has not found");

        var updatedItems = command.Products.Select(p => new CartItem(cart.Id, p.ProductId, p.Quantity)).ToArray();

        cart.UpdateItems(updatedItems);

        cart.UpdateDate();

        var updatedCart = await _cartRepository.UpdateAsync(cart, cancellationToken);

        return _mapper.Map<UpdateCartResult>(updatedCart);
    }
}
