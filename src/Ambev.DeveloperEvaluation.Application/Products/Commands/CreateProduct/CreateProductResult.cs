namespace Ambev.DeveloperEvaluation.Application.Products.Commands.CreateProduct
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
