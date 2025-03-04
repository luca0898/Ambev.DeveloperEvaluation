using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.Commands.UpdateBranch;

public class UpdateBranchHandler(IBranchRepository _branchRepository) : IRequestHandler<UpdateBranchCommand, UpdateBranchResult>
{
    public async Task<UpdateBranchResult> Handle(UpdateBranchCommand command, CancellationToken cancellationToken)
    {
        var branch = await _branchRepository.GetByIdAsync(command.Id, cancellationToken);

        _ = branch ?? throw new KeyNotFoundException($"Branch with ID {command.Id} has not found");

        branch.Name = command.Name;
        branch.Location = command.Location;
        branch.UpdatedAt = DateTime.UtcNow;

        await _branchRepository.UpdateAsync(branch, cancellationToken);

        return new UpdateBranchResult
        {
            Id = branch.Id,
            Name = branch.Name,
            Location = branch.Location
        };
    }
}

