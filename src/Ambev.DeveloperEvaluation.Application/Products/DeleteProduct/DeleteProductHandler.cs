using Ambev.DeveloperEvaluation.Domain.Models;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;

public class DeleteProductHandler(IProductRepository _productRepository) : IRequestHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new DeleteProductCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await _productRepository.DeleteAsync(command.Id, cancellationToken);

        return new DeleteProductResult { Success = result };
    }
}
