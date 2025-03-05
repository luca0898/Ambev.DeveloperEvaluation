using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Models.CartDomain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class CartRepository : ICartRepository
{
    private readonly DefaultContext _context;

    public CartRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        await _context.Carts.AddAsync(cart, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return cart;
    }

    public async Task<Cart> UpdateAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        _context.Carts.Update(cart);
        await _context.SaveChangesAsync(cancellationToken);
        return cart;
    }

    public async Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Carts
            .Include(cart => cart.Products)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public async Task<Cart?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _context.Carts
            .Include(cart => cart.Products)
            .FirstOrDefaultAsync(o => o.UserId == userId, cancellationToken);
    }

    public async Task<Cart[]?> GetAsync(CancellationToken cancellationToken = default)
    {
        var carts = await _context.Carts
            .Include(cart => cart.Products)
            .OrderBy(s => s.CreatedAt)
            .ToArrayAsync(cancellationToken);

        return carts;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cart = await GetByIdAsync(id, cancellationToken);
        if (cart == null)
            return false;

        _context.Carts.Remove(cart);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<IEnumerable<Cart>> GetAllAsync(int page, int size, string order, CancellationToken cancellationToken = default)
    {
        IQueryable<Cart> query = _context.Carts.Include(p => p.Products);

        if (!string.IsNullOrWhiteSpace(order))
            query = ApplyOrdering(query, order);

        query = query
            .Skip((page - 1) * size)
            .Take(size);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Carts.CountAsync(cancellationToken);
    }

    private IQueryable<Cart> ApplyOrdering(IQueryable<Cart> query, string order)
    {
        var orderFields = order.Split(',');

        foreach (var orderField in orderFields)
        {
            var parts = orderField.Trim().Split(' ');
            var propertyName = parts[0];
            var descending = parts.Length > 1 && parts[1].ToLower() == "desc";

            query = descending
                ? query.OrderByDescendingDynamic(propertyName)
                : query.OrderByDynamic(propertyName);
        }

        return query;
    }
}
