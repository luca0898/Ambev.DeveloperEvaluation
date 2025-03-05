using Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Dtos;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries
{
    public sealed record GetSaleResult(
    Guid Id,
    string SaleNumber,
    decimal TotalAmount,
    bool IsCancelled,
    Guid? CustomerId,
    Guid? BranchId,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    IEnumerable<SaleItemDto> Items);
}
