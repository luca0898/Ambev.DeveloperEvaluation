using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.DeleteUser;

public record DeleteUserCommand : IRequest<DeleteUserResult>
{
    public Guid Id { get; }
    public DeleteUserCommand(Guid id)
    {
        Id = id;
    }
}
