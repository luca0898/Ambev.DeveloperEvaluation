using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

public class DeleteCartItemCommandHandler(ICartRepository _cartRepository) : IRequestHandler<DeleteCartItemCommand, bool>
{
    public async Task<bool> Handle(DeleteCartItemCommand command, CancellationToken cancellationToken)
    {
        var validator = new DeleteCartItemValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cart = await _cartRepository.GetByUserIdAsync(command.UserId, cancellationToken);
        _ = cart ?? throw new KeyNotFoundException($"Cart for UserId {command.UserId} not found.");

        cart.RemoveProduct(command.ProductId);

        if (cart.Products.Count == 0)
        {
            await _cartRepository.DeleteAsync(cart.Id, cancellationToken);
        }
        else
        {
            await _cartRepository.UpdateAsync(cart, cancellationToken);
        }

        return true;
    }
}
