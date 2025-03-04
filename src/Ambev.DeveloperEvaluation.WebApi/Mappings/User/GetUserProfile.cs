using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.User;

public class GetUserProfile : Profile
{
    public GetUserProfile()
    {
        CreateMap<Guid, GetUserQuery>().ConstructUsing(id => new GetUserQuery(id));
        CreateMap<GetUserResult, GetUserResponse>().ReverseMap();
    }
}
