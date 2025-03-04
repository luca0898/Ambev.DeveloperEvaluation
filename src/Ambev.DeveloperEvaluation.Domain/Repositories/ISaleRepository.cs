using Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository
    {
        Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default); Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default); Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Sale[]?> GetAsync(CancellationToken cancellationToken = default); Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
