using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Users.CreateUser;

public class CreateUserProfile : Profile
{
    public CreateUserProfile()
    {
        CreateMap<CreateUserCommand, User>();
        CreateMap<User, CreateUserResult>();
    }
}
