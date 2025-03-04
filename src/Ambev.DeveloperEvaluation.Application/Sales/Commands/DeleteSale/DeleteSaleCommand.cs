using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.DeleteSale
{
    public sealed record DeleteSaleCommand(Guid Id) : IRequest<bool>;
}
