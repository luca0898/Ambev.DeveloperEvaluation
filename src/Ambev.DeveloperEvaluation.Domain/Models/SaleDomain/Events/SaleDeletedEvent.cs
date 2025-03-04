using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Events
{
    public record SaleDeletedEvent(string SaleNumber) : IDomainEvent;
}
