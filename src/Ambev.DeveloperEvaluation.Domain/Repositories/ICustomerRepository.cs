using Ambev.DeveloperEvaluation.Domain.Models;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateAsync(Customer customer, CancellationToken cancellationToken = default); 
        Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default); 
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Customer?> GetCustomerByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}
