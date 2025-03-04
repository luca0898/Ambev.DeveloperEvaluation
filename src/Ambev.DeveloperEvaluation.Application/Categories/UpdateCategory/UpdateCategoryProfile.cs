using Ambev.DeveloperEvaluation.Domain.Models;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Categories.UpdateCategory
{
    /// <summary>
    /// Profile for UpdateCategory mapping.
    /// </summary>
    public class UpdateCategoryProfile : Profile
    {
        public UpdateCategoryProfile()
        {
            CreateMap<UpdateCategoryCommand, Category>();
            CreateMap<Category, UpdateCategoryResult>();
        }
    }
}
