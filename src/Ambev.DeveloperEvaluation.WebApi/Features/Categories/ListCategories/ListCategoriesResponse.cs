namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.ListCategories
{
    public class ListCategoriesResponse
    {
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
