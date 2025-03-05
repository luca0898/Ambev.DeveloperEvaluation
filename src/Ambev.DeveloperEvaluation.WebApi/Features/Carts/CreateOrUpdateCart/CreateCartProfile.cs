using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateOrUpdateCart
{
    public class CreateOrUpdateCartProfile : Profile
    {
        public CreateOrUpdateCartProfile()
        {
            CreateMap<CartItemRequest, AddOrUpdateCartItemCommand>().ReverseMap();
        }
    }
}
