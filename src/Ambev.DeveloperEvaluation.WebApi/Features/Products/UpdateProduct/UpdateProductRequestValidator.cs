using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductRequestValidator()
    {
        RuleFor(product => product.Id).NotEmpty();

        RuleFor(product => product.Title).NotEmpty().NotNull().Length(3, 50);

        RuleFor(product => product.Price).NotEmpty().NotNull().GreaterThan(0);

        RuleFor(product => product.Description).NotEmpty().NotNull().Length(5, 500);

        RuleFor(product => product.Category).NotEmpty().NotNull();

        RuleFor(product => product.Image).NotEmpty().NotNull();

        RuleFor(product => product.Rating).NotNull().SetValidator(new ProductRatingRequestValidator());
    }
    public class ProductRatingRequestValidator : AbstractValidator<UpdateProductRatingRequest>
    {
        public ProductRatingRequestValidator()
        {
            RuleFor(rating => rating.Rate).InclusiveBetween(0, 5);

            RuleFor(rating => rating.Count).GreaterThanOrEqualTo(0);
        }
    }
}
