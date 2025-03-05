using Ambev.DeveloperEvaluation.Application.Branchs.Commands.CreateBranch;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch;

public class CreateBranchProfile : Profile
{
    public CreateBranchProfile()
    {
        CreateMap<CreateBranchRequest, CreateBranchCommand>().ReverseMap();
        CreateMap<CreateBranchResult, CreateBranchResponse>().ReverseMap();
    }
}