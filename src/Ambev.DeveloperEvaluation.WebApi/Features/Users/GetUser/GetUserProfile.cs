using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;

public class GetUserProfile : Profile
{
    public GetUserProfile()
    {
        CreateMap<Guid, GetUserQuery>().ConstructUsing(id => new GetUserQuery(id));
        CreateMap<GetUserResult, GetUserResponse>().ReverseMap();
    }
}
