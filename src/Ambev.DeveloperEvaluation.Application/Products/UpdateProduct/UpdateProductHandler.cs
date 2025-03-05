using Ambev.DeveloperEvaluation.Domain.Models;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

public class UpdateProductHandler(
    IProductRepository productRepository,
    ICategoryRepository categoryRepository,
    IMapper _mapper)
    : IRequestHandler<UpdateProductCommand, UpdateProductResult?>
{
    public async Task<UpdateProductResult?> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = await productRepository.GetByIdAsync(command.Id, cancellationToken);
        _ = product ?? throw new KeyNotFoundException($"Product with ID {command.Id} has not found");

        if (command.Category != product.Category.Name)
        {
            var category = await categoryRepository.GetByIdAsync(product.CategoryId, cancellationToken);
            _ = category ?? throw new KeyNotFoundException($"Category {command.Category} not found");

            product.CategoryId = category.Id;
            product.Category = category;
        }

        product.Title = command.Title;
        product.Price = command.Price;
        product.Description = command.Description;
        product.Image = command.Image;
        product.Rating = _mapper.Map<ProductRating>(command.Rating);
        product.UpdatedAt = DateTime.UtcNow;

        var updatedProduct = await productRepository.UpdateAsync(product, cancellationToken);

        return _mapper.Map<UpdateProductResult>(updatedProduct);
    }
}
