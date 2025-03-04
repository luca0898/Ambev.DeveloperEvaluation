using Ambev.DeveloperEvaluation.Application.Products.DTOs;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    public record CreateProductResult(
        Guid Id,
        string Title,
        decimal Price,
        string Description,
        string Category,
        string Image,
        ProductRatingDto Rating
    );
}
