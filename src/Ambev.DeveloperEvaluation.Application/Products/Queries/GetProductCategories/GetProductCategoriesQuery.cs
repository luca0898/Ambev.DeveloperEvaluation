using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.Queries.GetProductCategories
{
    /// <summary>
    /// Query to retrieve all product categories.
    /// </summary>
    public class GetProductCategoriesQuery : IRequest<List<string>>
    {
    }
}
