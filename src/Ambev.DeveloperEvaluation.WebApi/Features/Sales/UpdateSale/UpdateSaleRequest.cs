using Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Dtos;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public sealed record UpdateSaleRequest(
    string SaleNumber,
    decimal TotalAmount,
    bool IsCancelled,
    Guid? CustomerId,
    Guid? BranchId,
    IEnumerable<SaleItemDto> Items);
}
