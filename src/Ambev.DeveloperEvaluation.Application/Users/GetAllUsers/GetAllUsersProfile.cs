using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Users.GetAllUsers
{
    public class GetAllUsersProfile : Profile
    {
        public GetAllUsersProfile()
        {
            CreateMap<User, GetAllUsersResult>();
        }
    }
}
