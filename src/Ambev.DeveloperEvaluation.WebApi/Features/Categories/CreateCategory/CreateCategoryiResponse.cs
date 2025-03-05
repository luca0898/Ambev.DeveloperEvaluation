namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.CreateCategory
{
    public class CreateCategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
