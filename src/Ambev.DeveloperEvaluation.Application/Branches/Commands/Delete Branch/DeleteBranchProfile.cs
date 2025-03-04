using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Branches.Commands.DeleteBranch;

public class DeleteBranchProfile : Profile
{
    public DeleteBranchProfile()
    {
        CreateMap<Guid, DeleteBranchCommand>().ConstructUsing(id => new DeleteBranchCommand(id));
    }
}
