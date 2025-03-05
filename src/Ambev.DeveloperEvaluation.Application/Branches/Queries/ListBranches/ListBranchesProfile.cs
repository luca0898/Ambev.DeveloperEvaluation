using Ambev.DeveloperEvaluation.Domain.Models;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Branches.Queries.ListBranches;

public class ListBranchesProfile : Profile
{
    public ListBranchesProfile()
    {
        CreateMap<Branch, BranchDto>();
    }
}
