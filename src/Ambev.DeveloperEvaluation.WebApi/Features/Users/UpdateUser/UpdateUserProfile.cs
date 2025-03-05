using Ambev.DeveloperEvaluation.Application.Users.UpdateUser;
using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Common;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser;

public class UpdateUserProfile : Profile
{
    public UpdateUserProfile()
    {
        CreateMap<UpdateUserRequest, UpdateUserCommand>();
        CreateMap<UpdateUserResult, UpdateUserResponse>();
        CreateMap<AddressDto, AddressDetail>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.Zipcode, opt => opt.MapFrom(src => src.Zipcode))
                .ForMember(dest => dest.Geolocation, opt => opt.MapFrom(src => src.Geolocation));

        CreateMap<GeolocationDto, GeolocationDetail>()
            .ForMember(dest => dest.Lat, opt => opt.MapFrom(src => src.Lat))
            .ForMember(dest => dest.Long, opt => opt.MapFrom(src => src.Long));
    }
}