using Ambev.DeveloperEvaluation.Domain.Models;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Branchs.Commands.CreateBranch;

public class CreateBranchProfile : Profile
{
    public CreateBranchProfile()
    {
        CreateMap<CreateBranchCommand, Branch>().ReverseMap();
        CreateMap<Branch, CreateBranchResult>().ReverseMap();
    }
}
