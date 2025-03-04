using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(product => product.Title).NotEmpty().NotNull().Length(3, 50);

        RuleFor(product => product.Price).NotEmpty().NotNull().GreaterThan(0);

        RuleFor(product => product.Description).NotEmpty().NotNull().Length(5, 500);

        RuleFor(product => product.Category).NotEmpty().NotNull();

        RuleFor(product => product.Image).NotEmpty().NotNull();

        RuleFor(product => product.Rating).NotNull().SetValidator(new ProductRatingRequestValidator());
    }
}
