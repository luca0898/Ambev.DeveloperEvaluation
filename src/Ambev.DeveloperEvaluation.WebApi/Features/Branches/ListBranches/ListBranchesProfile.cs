using Ambev.DeveloperEvaluation.Application.Branches.Queries.ListBranches;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.ListBranches
{
    public class ListBranchesProfile : Profile
    {
        public ListBranchesProfile()
        {
            CreateMap<ListBranchesResult, ListBranchesResponse>();
        }
    }
}
