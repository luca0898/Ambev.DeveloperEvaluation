using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Application.Users.GetAllUsers;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetAllUsers;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

public class CreateUserProfile : Profile
{
    public CreateUserProfile()
    {
        CreateMap<CreateUserResult, CreateUserResponse>();
        CreateMap<CreateUserRequest, CreateUserCommand>();
        CreateMap<GetAllUsersRequest, GetAllUsersQuery>()
            .ForMember(dest => dest.Page, opt => opt.MapFrom(src => src.Page))
            .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size))
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order));
    }
}
