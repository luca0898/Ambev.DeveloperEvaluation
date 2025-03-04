namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    /// <summary>
    /// Represents a request to create a new product.
    /// </summary>
    public sealed record CreateProductRequest(
        string Title,
        decimal Price,
        string Description,
        string Category,
        string Image,
        ProductRatingRequest Rating
    );

    /// <summary>
    /// Represents the rating details of a product in the creation request.
    /// </summary>
    public sealed record ProductRatingRequest(double Rate, int Count);
}
