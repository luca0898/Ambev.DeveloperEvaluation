using Ambev.DeveloperEvaluation.Domain.Models.CartDomain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateOrUpdateCartProfile : Profile
{
    public CreateOrUpdateCartProfile()
    {
        CreateMap<Cart, CreateOrUpdateCartResult>().ReverseMap();
    }
}
