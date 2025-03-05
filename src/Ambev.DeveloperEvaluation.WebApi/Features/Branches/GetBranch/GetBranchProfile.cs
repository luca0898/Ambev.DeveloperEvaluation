using Ambev.DeveloperEvaluation.Application.Branches.Queries.GetBranch;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.GetBranch
{
    public class GetBranchProfile : Profile
    {
        public GetBranchProfile()
        {
            CreateMap<GetBranchResult, GetBranchResponse>();
        }
    }
}
