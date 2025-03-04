namespace Ambev.DeveloperEvaluation.Application.Categories.GetCategories
{
    /// <summary>
    /// Response for retrieving a single category.
    /// </summary>
    public class GetCategoryResult
    {
        /// <summary>
        /// The unique identifier of the category.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the category.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// A brief description of the category.
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
