namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.GetCategory
{
    /// <summary>
    /// Represents the request for getting a category by ID.
    /// </summary>
    public class GetCategoryRequest
    {
        public Guid Id { get; set; }
    }
}
