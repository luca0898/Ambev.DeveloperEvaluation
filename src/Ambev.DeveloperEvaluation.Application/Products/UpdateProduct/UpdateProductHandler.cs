using Ambev.DeveloperEvaluation.Domain.Models;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    public class UpdateProductHandler(IProductRepository _productRepository, IMapper _mapper) : IRequestHandler<UpdateProductCommand, UpdateProductResult?>
    {
        public async Task<UpdateProductResult?> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(command.Id, cancellationToken);
            _ = product ?? throw new KeyNotFoundException($"Product with ID {command.Id} has not found");

            product.Title = command.Title;
            product.Price = command.Price;
            product.Description = command.Description;
            product.Image = command.Image;
            product.CategoryId = command.Category;
            product.Rating = _mapper.Map<ProductRating>(command.Rating);
            product.UpdatedAt = DateTime.UtcNow;

            var updatedProduct = await _productRepository.UpdateAsync(product, cancellationToken);

            return _mapper.Map<UpdateProductResult>(updatedProduct);
        }
    }
}
