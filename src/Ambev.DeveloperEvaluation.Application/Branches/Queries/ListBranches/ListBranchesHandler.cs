using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.Queries.ListBranches;

public class ListBranchesHandler(IBranchRepository _branchRepository, IMapper _mapper) : IRequestHandler<ListBranchesQuery, ListBranchesResult>
{
    public async Task<ListBranchesResult> Handle(ListBranchesQuery request, CancellationToken cancellationToken)
    {
        var branches = await _branchRepository.GetPagedAsync(request.Page, request.Size, cancellationToken);

        return new ListBranchesResult
        {
            Branches = _mapper.Map<List<BranchDto>>(branches),
            TotalCount = await _branchRepository.GetCountAsync(cancellationToken)
        };
    }
}
