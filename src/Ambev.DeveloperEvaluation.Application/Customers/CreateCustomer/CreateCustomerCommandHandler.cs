using Ambev.DeveloperEvaluation.Domain.Models;
using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;

public class CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUserRepository userRepository, IMapper mapper, IMediator mediator)
: IRequestHandler<CreateCustomerCommand, CreateCustomerResult>
{
    public async Task<CreateCustomerResult> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCustomerCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        User user = await userRepository.GetByIdAsync(command.UserId, cancellationToken);
        _ = user ?? throw new KeyNotFoundException($"User with ID {command.UserId} not found");

        var customer = mapper.Map<Customer>(user);

        var createdCustomer = await customerRepository.CreateAsync(customer, cancellationToken);

        return mapper.Map<CreateCustomerResult>(createdCustomer);
    }
}
