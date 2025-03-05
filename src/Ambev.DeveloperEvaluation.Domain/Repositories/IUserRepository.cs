﻿using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user, CancellationToken cancellationToken = default); Task<User> UpdateAsync(User user, CancellationToken cancellationToken = default); Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default); Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default); Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<User>> GetAllAsync(int page, int size, string order, CancellationToken cancellationToken = default); Task<int> CountAsync(CancellationToken cancellationToken = default);
    }
}
