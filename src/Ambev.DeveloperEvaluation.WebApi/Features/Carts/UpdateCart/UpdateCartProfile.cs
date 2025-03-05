using Ambev.DeveloperEvaluation.Application.Carts;
using Ambev.DeveloperEvaluation.Application.Carts.Commands.UpdateCart;
using Ambev.DeveloperEvaluation.Domain.Models.CartDomain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.DTOs;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart
{
    public class UpdateCartProfile : Profile
    {
        public UpdateCartProfile()
        {
            CreateMap<Cart, UpdateCartResult>();
            CreateMap<CartItem, CartItemResult>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id));
            CreateMap<UpdateCartRequest, UpdateCartCommand>();
            CreateMap<UpdateCartResponse, UpdateCartResult>().ReverseMap();
            CreateMap<CartItemDto, CartItemCommand>().ReverseMap();
        }
    }

}
