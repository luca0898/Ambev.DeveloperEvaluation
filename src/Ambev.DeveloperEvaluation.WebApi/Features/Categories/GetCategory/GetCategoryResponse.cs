namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.GetCategory
{
    /// <summary>
    /// Represents the response for getting a category by ID.
    /// </summary>
    public class GetCategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
