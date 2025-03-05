using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSale
{
    public sealed record CancelItemCommand(Guid SaleId, Guid ItemId) : IRequest<bool>;
}
