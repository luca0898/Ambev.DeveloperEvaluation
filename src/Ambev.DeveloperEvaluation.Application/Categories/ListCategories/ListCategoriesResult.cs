using Ambev.DeveloperEvaluation.Application.Categories.DTOs;

namespace Ambev.DeveloperEvaluation.Application.Categories.ListCategories
{
    /// <summary>
    /// Response for listing categories with pagination.
    /// </summary>
    public class ListCategoriesResult
    {
        /// <summary>
        /// List of categories.
        /// </summary>
        public List<CategoryDto> Categories { get; set; } = new();

        /// <summary>
        /// Total number of categories available.
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
}
