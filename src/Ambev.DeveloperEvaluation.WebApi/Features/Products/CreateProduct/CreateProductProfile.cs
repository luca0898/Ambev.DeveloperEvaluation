using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.DTOs;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>();
        CreateMap<CreateProductRatingRequest, ProductRatingDto>();
        CreateMap<CreateProductResult, CreateProductResponse>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
    }
}
