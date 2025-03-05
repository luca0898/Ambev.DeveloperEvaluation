using Ambev.DeveloperEvaluation.Application.Commons;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts
{
    public class GetAllProductsQuery : IRequest<PaginatedResponse<GetAllProductsResult>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public string Order { get; set; } = string.Empty;
    }
}
