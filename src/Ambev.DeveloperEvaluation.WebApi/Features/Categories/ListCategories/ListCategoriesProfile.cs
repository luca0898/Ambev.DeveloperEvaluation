using Ambev.DeveloperEvaluation.Application.Categories.ListCategories;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.ListCategories
{
    /// <summary>
    /// Profile for mapping ListCategories operations.
    /// </summary>
    public class ListCategoriesProfile : Profile
    {
        public ListCategoriesProfile()
        {
            CreateMap<ListCategoriesResult, ListCategoriesResponse>();
        }
    }
}
