using Ambev.DeveloperEvaluation.Application.Categories.UpdateCategory;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.UpdateCategory
{
    public class UpdateCategoryProfile : Profile
    {
        public UpdateCategoryProfile()
        {
            CreateMap<UpdateCategoryRequest, UpdateCategoryCommand>();
            CreateMap<UpdateCategoryResult, UpdateCategoryResponse>();
        }
    }
}
