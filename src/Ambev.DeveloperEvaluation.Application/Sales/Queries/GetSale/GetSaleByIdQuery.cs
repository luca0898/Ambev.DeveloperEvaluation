using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSale
{
    public sealed record GetSaleByIdQuery(Guid Id) : IRequest<GetSaleResult>;
}
