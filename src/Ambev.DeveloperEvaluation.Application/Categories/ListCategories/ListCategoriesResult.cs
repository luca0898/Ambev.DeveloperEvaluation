using Ambev.DeveloperEvaluation.Application.Categories.DTOs;

namespace Ambev.DeveloperEvaluation.Application.Categories.ListCategories
{
    public class ListCategoriesResult
    {
        public List<CategoryDto> Categories { get; set; } = new();
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
