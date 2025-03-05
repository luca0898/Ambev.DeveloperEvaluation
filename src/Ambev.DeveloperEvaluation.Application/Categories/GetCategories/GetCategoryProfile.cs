using Ambev.DeveloperEvaluation.Domain.Models;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Categories.GetCategories;

public class GetCategoryProfile : Profile
{
    public GetCategoryProfile()
    {
        CreateMap<Category, GetCategoryResult>();
    }
}
