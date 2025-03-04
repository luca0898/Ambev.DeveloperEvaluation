namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public sealed record CreateProductRequest(
    string Title,
    decimal Price,
    string Description,
    string Category,
    string Image,
    ProductRatingRequest Rating
);
public sealed record ProductRatingRequest(double Rate, int Count);
