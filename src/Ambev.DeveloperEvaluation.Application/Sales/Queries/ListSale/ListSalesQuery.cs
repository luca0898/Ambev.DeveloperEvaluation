using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.ListSale
{
    public sealed record ListSalesQuery : IRequest<IEnumerable<GetSaleResult>>;
}
