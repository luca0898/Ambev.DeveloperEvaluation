using Ambev.DeveloperEvaluation.Application.Products.DTOs;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(product => product.Title).NotEmpty().MaximumLength(100);

        RuleFor(product => product.Price).GreaterThan(0);

        RuleFor(product => product.Description).NotEmpty().MaximumLength(500);

        RuleFor(product => product.Category).NotEmpty();

        RuleFor(product => product.Image).NotEmpty();

        RuleFor(product => product.Rating).NotNull().SetValidator(new ProductRatingDtoValidator());
    }
}

public class ProductRatingDtoValidator : AbstractValidator<ProductRatingDto>
{
    public ProductRatingDtoValidator()
    {
        RuleFor(rating => rating.Rate).InclusiveBetween(0, 5);

        RuleFor(rating => rating.Count).GreaterThanOrEqualTo(0);
    }
}
