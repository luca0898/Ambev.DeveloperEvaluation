namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.ListCategories
{
    /// <summary>
    /// Represents the request for listing categories.
    /// </summary>
    public class ListCategoriesRequest
    {
        /// <summary>
        /// The page number for pagination. Defaults to 1.
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// The number of items per page. Defaults to 10.
        /// </summary>
        public int Size { get; set; } = 10;

        /// <summary>
        /// Optional ordering of the results.
        /// </summary>
        public string? Order { get; set; }
    }
}
