using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Events
{
    public record SaleCreatedEvent(Sale Sale) : IDomainEvent;
}
