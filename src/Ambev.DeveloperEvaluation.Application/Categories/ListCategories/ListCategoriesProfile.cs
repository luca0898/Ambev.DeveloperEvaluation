using Ambev.DeveloperEvaluation.Application.Categories.DTOs;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Models;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Categories.ListCategories;

public class ListCategoriesProfile : Profile
{
    public ListCategoriesProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<PaginatedList<Category>, ListCategoriesResult>();
    }
}
