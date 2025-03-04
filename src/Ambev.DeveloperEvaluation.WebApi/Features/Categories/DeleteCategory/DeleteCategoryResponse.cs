namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.DeleteCategory
{
    /// <summary>
    /// Represents the response after a category is deleted.
    /// </summary>
    public class DeleteCategoryResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = "Category deleted successfully.";
    }
}
