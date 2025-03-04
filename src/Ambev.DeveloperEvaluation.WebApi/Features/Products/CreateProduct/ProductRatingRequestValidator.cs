using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class ProductRatingRequestValidator : AbstractValidator<ProductRatingRequest>
{
    public ProductRatingRequestValidator()
    {
        RuleFor(rating => rating.Rate).InclusiveBetween(0, 5);

        RuleFor(rating => rating.Count).GreaterThanOrEqualTo(0);
    }
}
