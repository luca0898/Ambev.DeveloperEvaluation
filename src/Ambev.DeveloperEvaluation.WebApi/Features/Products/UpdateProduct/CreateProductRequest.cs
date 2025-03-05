namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

public sealed record UpdateProductRequest(
    Guid Id,
    string Title,
    decimal Price,
    string Description,
    string Category,
    string Image,
    UpdateProductRatingRequest Rating
);
public sealed record UpdateProductRatingRequest(double Rate, int Count);
