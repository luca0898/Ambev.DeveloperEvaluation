using Ambev.DeveloperEvaluation.Application.Products.ListProducts;
using Ambev.DeveloperEvaluation.Domain.Models;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProducts
{
    public class ListProductsProfile: Profile
    {
        public ListProductsProfile()
        {
            CreateMap<GetAllProductsResult, ListProductsResponse>();

            CreateMap<Product, GetAllProductsResult>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => new GetAllProductRating(src.Rating.Rate, src.Rating.Count)));

            CreateMap<ProductRating, GetAllProductRating>()
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rate))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count));
        }
    }
}
