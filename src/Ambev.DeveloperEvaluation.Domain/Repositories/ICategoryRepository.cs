using Ambev.DeveloperEvaluation.Domain.Models;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ICategoryRepository
{
    Task<Category> CreateAsync(Category category, CancellationToken cancellationToken = default); Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default); Task<Category> UpdateAsync(Category category, CancellationToken cancellationToken = default); Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default); Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default); Task<Category?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<List<Category>> GetCategoriesAsync(int page, int size, CancellationToken cancellationToken = default);
    Task<int> GetTotalCountAsync(CancellationToken cancellationToken = default);
}
