using Ambev.DeveloperEvaluation.Application.Commons;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUser;

public record GetAllUsersCommand : IRequest<PaginatedResponse<GetUserResult>>
{
    public int Page { get; init; } = 1;
    public int Size { get; init; } = 10;
    public string? Order { get; init; }
}
