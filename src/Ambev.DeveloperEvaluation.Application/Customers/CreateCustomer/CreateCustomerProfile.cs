using Ambev.DeveloperEvaluation.Domain.Models;
using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;

public class CreateCustomerProfile : Profile
{
    public CreateCustomerProfile()
    {
        CreateMap<User, Customer>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap();

        CreateMap<CreateCustomerCommand, Customer>().ReverseMap();
        CreateMap<Customer, CreateCustomerResult>().ReverseMap();
    }
}
