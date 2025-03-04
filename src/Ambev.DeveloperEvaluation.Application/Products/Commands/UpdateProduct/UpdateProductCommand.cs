using Ambev.DeveloperEvaluation.Application.Products.Commands.CreateProduct;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<UpdateProductResult>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public Guid Category { get; set; }
    public string Image { get; set; } = string.Empty;
    public ProductRatingDto Rating { get; set; } = new ProductRatingDto(0, 0);
}
