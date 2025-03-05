using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.Queries.GetBranch;

public sealed record GetBranchQuery(Guid Id) : IRequest<GetBranchResult>;
