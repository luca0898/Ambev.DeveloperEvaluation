using Ambev.DeveloperEvaluation.Domain.Models;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class BranchRepository : IBranchRepository
{
    private readonly DefaultContext _context;
    public BranchRepository(DefaultContext context)
    {
        _context = context;
    }
    public async Task<Branch> CreateAsync(Branch branch, CancellationToken cancellationToken = default)
    {
        _ = await _context.Branches.AddAsync(branch, cancellationToken);
        _ = await _context.SaveChangesAsync(cancellationToken);
        return branch;
    }
    public async Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Branches.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Branch? branch = await GetByIdAsync(id, cancellationToken);
        if (branch == null) { return false; }
        _ = _context.Branches.Remove(branch);
        _ = await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<Branch> UpdateAsync(Branch branch, CancellationToken cancellationToken = default)
    {
        _ = _context.Branches.Update(branch);
        _ = await _context.SaveChangesAsync(cancellationToken);
        return branch;
    }

    public async Task<List<Branch>> GetPagedAsync(int page, int size, CancellationToken cancellationToken = default)
    {
        return await _context.Branches
            .OrderBy(b => b.Name)
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> GetCountAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Branches.CountAsync(cancellationToken);
    }
}
