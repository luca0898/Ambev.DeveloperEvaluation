using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Models;
using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Entities;
using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.CreateUser;

public class CreateUserHandler(
    IUserRepository userRepository,
    ICustomerRepository customerRepository,
    IMapper mapper,
    IPasswordHasher passwordHasher)
    : IRequestHandler<CreateUserCommand, CreateUserResult>
{

    public async Task<CreateUserResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateUserCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingUser = await userRepository.GetByEmailAsync(command.Email, cancellationToken);
        if (existingUser != null)
            throw new InvalidOperationException($"User with email {command.Email} already exists");

        var user = mapper.Map<User>(command);
        user.Password = passwordHasher.HashPassword(command.Password);

        var createdUser = await userRepository.CreateAsync(user, cancellationToken);

        if (createdUser.Role == UserRole.Customer)
        {
            var existingCustomer = await customerRepository.GetUserByIdAsync(createdUser.Id, cancellationToken);

            if (existingCustomer is null)
            {
                var customer = mapper.Map<Customer>(createdUser);

                await customerRepository.CreateAsync(customer, cancellationToken);
            }
        }

        return mapper.Map<CreateUserResult>(createdUser);
    }
}
