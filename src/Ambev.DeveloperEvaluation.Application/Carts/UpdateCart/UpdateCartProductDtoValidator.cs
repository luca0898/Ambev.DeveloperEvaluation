using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.UpdateCart;

public class UpdateCartProductDtoValidator : AbstractValidator<UpdateCartProductDto>
{
    public UpdateCartProductDtoValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
    }
}
