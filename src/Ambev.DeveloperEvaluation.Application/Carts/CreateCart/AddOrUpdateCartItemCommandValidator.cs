using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class AddOrUpdateCartItemCommandValidator : AbstractValidator<AddOrUpdateCartItemCommand>
{
    public AddOrUpdateCartItemCommandValidator()
    {
        RuleFor(cart => cart.ProductId).NotEmpty();
        RuleFor(cart => cart.UserId).NotEmpty();
        RuleFor(cart => cart.Quantity).NotEmpty().NotEqual(0);
    }
}
