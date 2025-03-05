using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.Commands.DeleteBranch;

public class DeleteBranchHandler(IBranchRepository _branchRepository) : IRequestHandler<DeleteBranchCommand, DeleteBranchResult>
{
    public async Task<DeleteBranchResult> Handle(DeleteBranchCommand command, CancellationToken cancellationToken)
    {
        var branch = await _branchRepository.GetByIdAsync(command.Id, cancellationToken);

        _ = branch ?? throw new KeyNotFoundException($"Branch with ID {command.Id} not found.");

        await _branchRepository.DeleteAsync(branch.Id, cancellationToken);
        return new DeleteBranchResult { Success = true };
    }
}
