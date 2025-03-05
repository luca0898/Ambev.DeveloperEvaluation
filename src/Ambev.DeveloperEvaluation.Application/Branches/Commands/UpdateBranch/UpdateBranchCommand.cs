using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.Commands.UpdateBranch;

public sealed record UpdateBranchCommand : IRequest<UpdateBranchResult>
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Location { get; init; } = string.Empty;
}
