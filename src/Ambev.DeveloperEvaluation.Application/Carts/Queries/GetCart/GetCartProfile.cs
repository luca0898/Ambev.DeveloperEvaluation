using Ambev.DeveloperEvaluation.Domain.Models.CartDomain.Dtos;
using Ambev.DeveloperEvaluation.Domain.Models.CartDomain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCart;

public class GetCartsProfile : Profile
{
    public GetCartsProfile()
    {
        CreateMap<Cart, GetCartResult>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
            .ReverseMap();

        CreateMap<CartItem, CartItemDto>().ReverseMap();
    }
}
