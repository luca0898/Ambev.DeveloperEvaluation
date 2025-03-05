using Ambev.DeveloperEvaluation.Application.Categories.GetCategories;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.GetCategory
{
    public class GetCategoryProfile : Profile
    {
        public GetCategoryProfile()
        {
            CreateMap<GetCategoryResult, GetCategoryResponse>();
        }
    }
}
