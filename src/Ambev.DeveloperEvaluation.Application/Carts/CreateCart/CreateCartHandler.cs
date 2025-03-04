using Ambev.DeveloperEvaluation.Domain.Models.CartDomain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartHandler(ICartRepository _cartRepository, IMapper _mapper) : IRequestHandler<CreateCartCommand, CreateCartResult>
{
    public async Task<CreateCartResult> Handle(CreateCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCartCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var createdCart = await _cartRepository.CreateAsync(_mapper.Map<Cart>(command), cancellationToken);

        return _mapper.Map<CreateCartResult>(createdCart);
    }
}
