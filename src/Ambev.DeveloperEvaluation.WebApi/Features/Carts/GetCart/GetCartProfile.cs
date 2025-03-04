using Ambev.DeveloperEvaluation.Application.Carts;
using Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCartById;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.DTOs;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart
{
    public class GetCartProfile : Profile
    {
        public GetCartProfile()
        {
            CreateMap<GetCartResponse, GetCartByIdResult>().ReverseMap();
            CreateMap<CartItemDto, CartItemCommand>().ReverseMap();
        }
    }
}
