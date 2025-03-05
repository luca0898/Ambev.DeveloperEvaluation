using Ambev.DeveloperEvaluation.Domain.Models;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProducts
{
    public class ListProductsResponse
    {
        public IEnumerable<Product> Products { get; set; } = [];
        public int TotalRecords { get; set; }
    }
}
