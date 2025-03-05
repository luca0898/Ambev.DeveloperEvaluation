using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.Queries.GetBranch;

public class GetBranchHandler(IBranchRepository _branchRepository, IMapper _mapper) : IRequestHandler<GetBranchQuery, GetBranchResult>
{
    public async Task<GetBranchResult> Handle(GetBranchQuery request, CancellationToken cancellationToken)
    {
        var branch = await _branchRepository.GetByIdAsync(request.Id, cancellationToken);

        _ = branch ?? throw new KeyNotFoundException($"Branch with ID {request.Id} has not found");

        return _mapper.Map<GetBranchResult>(branch);
    }
}
