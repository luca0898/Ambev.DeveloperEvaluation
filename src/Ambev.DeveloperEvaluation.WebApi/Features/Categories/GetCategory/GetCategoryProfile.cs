using Ambev.DeveloperEvaluation.Application.Categories.GetCategories;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.GetCategory
{
    /// <summary>
    /// Profile for GetCategory mapping.
    /// </summary>
    public class GetCategoryProfile : Profile
    {
        public GetCategoryProfile()
        {
            CreateMap<GetCategoryResult, GetCategoryResponse>();
        }
    }
}
