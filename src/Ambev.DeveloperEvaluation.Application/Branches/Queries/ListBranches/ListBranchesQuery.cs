using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.Queries.ListBranches;

public sealed record ListBranchesQuery(int Page, int Size, string? Order = null) : IRequest<ListBranchesResult>;
