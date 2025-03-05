using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Events
{
    public record ItemCancelledEvent(Sale Sale, SaleItem Item) : IDomainEvent;
}
