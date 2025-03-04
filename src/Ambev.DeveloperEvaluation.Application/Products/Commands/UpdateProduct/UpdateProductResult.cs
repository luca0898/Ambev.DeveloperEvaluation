using Ambev.DeveloperEvaluation.Application.Products.Commands.CreateProduct;

namespace Ambev.DeveloperEvaluation.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }

        ProductRatingDto Rating { get; set; }
    }
}
