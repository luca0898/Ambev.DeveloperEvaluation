using Ambev.DeveloperEvaluation.Domain.Models.CartDomain.Dtos;
using Ambev.DeveloperEvaluation.Domain.Models.CartDomain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetAllCarts;

public class GetAllCartsProfile : Profile
{
    public GetAllCartsProfile()
    {
        CreateMap<Cart, GetAllCartsResult>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
            .ReverseMap();

        CreateMap<CartItem, GetAllCartsItemResult>().ReverseMap();
    }
}
