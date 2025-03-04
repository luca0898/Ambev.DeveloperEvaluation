﻿using Ambev.DeveloperEvaluation.Domain.Models;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IBranchRepository
    {
        /// <summary>
        /// Creates a new branch in the repository.
        /// </summary>
        /// <param name="branch">The branch to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The created branch.</returns>
        Task<Branch> CreateAsync(Branch branch, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a branch by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the branch.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The branch if found, null otherwise.</returns>
        Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing branch.
        /// </summary>
        /// <param name="branch">The branch to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The updated branch.</returns>
        Task<Branch> UpdateAsync(Branch branch, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a branch from the repository.
        /// </summary>
        /// <param name="id">The unique identifier of the branch to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>True if the branch was deleted, false if not found.</returns>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a paginated list of branches.
        /// </summary>
        /// <param name="page">The page number to retrieve.</param>
        /// <param name="size">The size of the page.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A paginated list of branches.</returns>
        Task<List<Branch>> GetPagedAsync(int page, int size, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the total count of branches in the repository.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The total count of branches.</returns>
        Task<int> GetCountAsync(CancellationToken cancellationToken = default);
    }
}
