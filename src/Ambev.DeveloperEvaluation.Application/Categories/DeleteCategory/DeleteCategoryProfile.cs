using Ambev.DeveloperEvaluation.Domain.Models;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Categories.DeleteCategory;

public class DeleteCategoryProfile : Profile
{
    public DeleteCategoryProfile()
    {
        CreateMap<Category, DeleteCategoryResult>();
    }
}
