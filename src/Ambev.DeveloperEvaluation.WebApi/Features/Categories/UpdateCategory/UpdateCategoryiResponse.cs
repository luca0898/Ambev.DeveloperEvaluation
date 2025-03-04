namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.UpdateCategory
{
    public class UpdateCategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; }
    }
}
