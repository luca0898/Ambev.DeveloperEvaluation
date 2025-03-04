using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct
{
    public record DeleteProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
