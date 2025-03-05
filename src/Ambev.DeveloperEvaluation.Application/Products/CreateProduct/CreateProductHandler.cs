using Ambev.DeveloperEvaluation.Domain.Models;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductHandler(IProductRepository _productRepository, ICategoryRepository _categoryRepository, IMapper _mapper)
    : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var category = await _categoryRepository.GetByNameAsync(command.Category, cancellationToken);
        _ = category ?? throw new KeyNotFoundException($"Category {command.Category} not found");

        var product = _mapper.Map<Product>(command);
        product.CategoryId = category.Id;
        product.Category = category;

        var createdProduct = await _productRepository.CreateAsync(product, cancellationToken);

        return _mapper.Map<CreateProductResult>(createdProduct);
    }
}
