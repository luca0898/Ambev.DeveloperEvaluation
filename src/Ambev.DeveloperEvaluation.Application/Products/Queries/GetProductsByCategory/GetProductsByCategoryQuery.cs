using Ambev.DeveloperEvaluation.Application.Products.DTOs;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryQuery : IRequest<PaginatedResult<ProductDto>>
    {
        public string Category { get; set; } = string.Empty;
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public string? Order { get; set; }
    }
}
