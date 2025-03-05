namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.DeleteCategory
{
    public class DeleteCategoryResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = "Category deleted successfully.";
    }
}
