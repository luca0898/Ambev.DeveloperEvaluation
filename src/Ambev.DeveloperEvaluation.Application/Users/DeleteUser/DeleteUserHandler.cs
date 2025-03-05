using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.DeleteUser;

public class DeleteUserHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand, DeleteUserResult>
{
    public async Task<DeleteUserResult> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var validator = new DeleteUserValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
        {
            return new DeleteUserResult
            {
                Success = false,
                Message = "Validation failed",
                Errors = validationResult.Errors.Select(e => new ValidationErrorDetail
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                }).ToList()
            };
        }

        var user = await userRepository.GetByIdAsync(command.Id, cancellationToken);
        if (user == null)
        {
            return new DeleteUserResult { Success = false, Message = $"User with ID {command.Id} not found." };
        }

        var success = await userRepository.DeleteAsync(command.Id, cancellationToken);
        if (!success)
        {
            return new DeleteUserResult
            {
                Success = false,
                Message = $"Failed to delete user with ID {command.Id}."
            };
        }

        return new DeleteUserResult { Success = true };
    }
}