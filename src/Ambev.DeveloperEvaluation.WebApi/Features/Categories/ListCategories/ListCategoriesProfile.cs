using Ambev.DeveloperEvaluation.Application.Categories.ListCategories;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.ListCategories
{
    public class ListCategoriesProfile : Profile
    {
        public ListCategoriesProfile()
        {
            CreateMap<ListCategoriesResult, ListCategoriesResponse>();
        }
    }
}
