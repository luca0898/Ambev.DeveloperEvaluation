using Ambev.DeveloperEvaluation.Domain.Models;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IBranchRepository
    {
        Task<Branch> CreateAsync(Branch branch, CancellationToken cancellationToken = default); Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default); Task<Branch> UpdateAsync(Branch branch, CancellationToken cancellationToken = default); Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Branch>> GetPagedAsync(int page, int size, CancellationToken cancellationToken = default); Task<int> GetCountAsync(CancellationToken cancellationToken = default);
    }
}
