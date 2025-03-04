using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.Application.Products.DTOs;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

public class UpdateProductProfile : Profile
{
    public UpdateProductProfile()
    {
        CreateMap<UpdateProductRequest, UpdateProductCommand>();
        CreateMap<UpdateProductRatingRequest, ProductRatingDto>();
        CreateMap<UpdateProductResult, UpdateProductResponse>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
    }
}
