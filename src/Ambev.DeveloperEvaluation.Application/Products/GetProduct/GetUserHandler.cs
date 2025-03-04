using Ambev.DeveloperEvaluation.Domain.Models;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public class GetProductHandler(IProductRepository productRepository, IMapper _mapper) : IRequestHandler<GetProductQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var validator = new GetProductValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = await productRepository.GetByIdAsync(request.Id, cancellationToken);
        _ = product ?? throw new KeyNotFoundException($"Product with ID {request.Id} not found");

        return _mapper.Map<GetProductResult>(product);
    }
}
