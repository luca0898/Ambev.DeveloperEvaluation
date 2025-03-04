using Ambev.DeveloperEvaluation.Application.Carts.Queries.ListCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCart
{
    public class ListCartProfile : Profile
    {
        public ListCartProfile()
        {
            CreateMap<ListCartsResponse, ListCartsResult>().ReverseMap();
            CreateMap<GetCartResponse, CartDto>().ReverseMap();
        }
    }
}
