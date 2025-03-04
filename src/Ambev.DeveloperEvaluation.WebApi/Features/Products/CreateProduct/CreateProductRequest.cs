namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public sealed record CreateProductRequest(
    string Title,
    decimal Price,
    string Description,
    string Category,
    string Image,
    CreateProductRatingRequest Rating
);
public sealed record CreateProductRatingRequest(double Rate, int Count);
