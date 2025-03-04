using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomerByUserId;

public class GetCustomerByUserIdCommandHandler(ICustomerRepository customerRepository, IMapper mapper) 
    : IRequestHandler<GetCustomerByUserIdCommand, GetCustomerByUserIdResult>
{
    public async Task<GetCustomerByUserIdResult> Handle(GetCustomerByUserIdCommand command, CancellationToken cancellationToken)
    {
        var validator = new GetCustomerByUserIdCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var customer = await customerRepository.GetCustomerByUserIdAsync(command.UserId, cancellationToken);
        _ = customer ?? throw new KeyNotFoundException($"Customer with UserId {command.UserId} not found");

        return mapper.Map<GetCustomerByUserIdResult>(customer);
    }
}
