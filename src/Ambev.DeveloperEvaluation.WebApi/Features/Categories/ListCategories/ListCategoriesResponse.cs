namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.ListCategories
{
    /// <summary>
    /// Response object for listing categories.
    /// </summary>
    public class ListCategoriesResponse
    {
        /// <summary>
        /// The list of categories.
        /// </summary>
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        /// <summary>
        /// Total count of categories.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Current page number.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Total number of pages.
        /// </summary>
        public int TotalPages { get; set; }
    }

    /// <summary>
    /// Data Transfer Object for a single category.
    /// </summary>
    public class CategoryDto
    {
        /// <summary>
        /// The ID of the category.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the category.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
