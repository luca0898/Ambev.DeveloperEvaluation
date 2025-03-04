using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Application.Users.ListUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

public class CreateUserProfile : Profile
{
    public CreateUserProfile()
    {
        CreateMap<CreateUserRequest, CreateUserCommand>();
        CreateMap<GetListUsersRequest, GetAllUsersCommand>()
            .ForMember(dest => dest.Page, opt => opt.MapFrom(src => src.PageNumber))
            .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.PageSize))
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.OrderBy));
    }
}
