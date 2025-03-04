using Ambev.DeveloperEvaluation.Application.Products.DTOs;
using Ambev.DeveloperEvaluation.Domain.Models;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {
        CreateMap<CreateProductCommand, Product>()
            .ForMember(dest => dest.CategoryId, opt => opt.Ignore())
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating));

        CreateMap<Product, CreateProductResult>()
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => new ProductRatingDto(src.Rating.Rate, src.Rating.Count)));

        CreateMap<ProductRatingDto, ProductRating>().ReverseMap();
    }
}
