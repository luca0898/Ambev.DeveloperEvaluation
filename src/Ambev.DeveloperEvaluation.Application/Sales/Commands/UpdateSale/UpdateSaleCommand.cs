using Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Dtos;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.UpdateSale
{
    public sealed record UpdateSaleCommand(
    Guid Id,
    string SaleNumber,
    decimal TotalAmount,
    bool IsCancelled,
    Guid? CustomerId,
    Guid? BranchId,
    IEnumerable<SaleItemDto> Items
) : IRequest<UpdateSaleResult>
    {
        public UpdateSaleCommand() : this(default, string.Empty, 0, false, null, null, [])
        {
        }
    }
}
