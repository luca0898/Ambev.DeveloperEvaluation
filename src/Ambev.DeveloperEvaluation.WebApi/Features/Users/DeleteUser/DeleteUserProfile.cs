using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.DeleteUser;

public class DeleteUserProfile : Profile
{
    public DeleteUserProfile()
    {
        CreateMap<Guid, DeleteUserCommand>()
            .ConstructUsing(id => new DeleteUserCommand(id));
        CreateMap<DeleteUserResult, DeleteUserResponse>();
    }
}
