using Ambev.DeveloperEvaluation.Application.Products.DTOs;
using Ambev.DeveloperEvaluation.Domain.Models;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public class GetProductProfile : Profile
{
    public GetProductProfile()
    {
        CreateMap<Product, GetProductResult>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
            .ReverseMap()
            .ForMember(dest => dest.Category, opt => opt.Ignore());
        CreateMap<ProductRating, ProductRatingDto>();
    }
}
