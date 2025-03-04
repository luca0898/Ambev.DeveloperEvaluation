using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.Commands.CreateProduct
{
    public record CreateProductCommand(
        string Title,
        decimal Price,
        string Description,
        string Category,
        string Image,
        ProductRatingDto Rating
    ) : IRequest<CreateProductResult>;

    public sealed record ProductRatingDto(double Rate, int Count);
}
