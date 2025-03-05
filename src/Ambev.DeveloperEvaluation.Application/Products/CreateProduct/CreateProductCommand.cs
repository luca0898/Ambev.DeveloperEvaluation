using Ambev.DeveloperEvaluation.Application.Products.DTOs;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public record CreateProductCommand(
    string Title,
    decimal Price,
    string Description,
    string Category,
    string Image,
    ProductRatingDto Rating
) : IRequest<CreateProductResult>;
