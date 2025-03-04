using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.Queries.GetProductCategories
{
    public class GetProductCategoriesQuery : IRequest<List<string>>
    {
    }
}
