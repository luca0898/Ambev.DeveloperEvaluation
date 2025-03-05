using Ambev.DeveloperEvaluation.Application.Commons;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.GetAllUsers;

public record GetAllUsersQuery : IRequest<PaginatedResult<GetAllUsersResult>>
{
    public int Page { get; set; }
    public int Size { get; set; }
    public string Order { get; set; } = string.Empty;
}
