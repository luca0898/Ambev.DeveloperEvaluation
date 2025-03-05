using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Models;
using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DefaultContext _context;

    public ProductRepository(DefaultContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Rating)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await GetByIdAsync(id, cancellationToken);
        if (product == null)
            return false;

        _context.Products.Remove(product);

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<List<Product>> GetProductsAsync(
        int page,
        int size,
        string? order,
        Dictionary<string, string>? filters,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Products.Include(p => p.Category).AsQueryable();

        if (filters != null)
        {
            foreach (var filter in filters)
            {
                if (filter.Key == "category") query = query.Where(p => p.Category.Name == filter.Value);
            }
        }

        if (!string.IsNullOrEmpty(order))
        {
            query = ApplyOrdering(query, order);
        }

        var paginatedProducts = await query
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync(cancellationToken);

        return paginatedProducts;
    }

    public async Task<List<string>> GetCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Categories
            .Select(c => c.Name)
            .Distinct()
            .ToListAsync(cancellationToken);
    }
    public async Task<PaginatedList<Product>> GetProductsByCategoryAsync(
        string category,
        int page,
        int size,
        string? order,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Products
            .Include(p => p.Rating)
            .Include(p => p.Category)
            .Where(p => p.Category.Name == category)
            .AsNoTracking();

        if (!string.IsNullOrEmpty(order))
        {
            query = ApplyOrdering(query, order);
        }

        var totalItems = await query.CountAsync(cancellationToken);
        var items = await query
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync(cancellationToken);

        return PaginatedList<Product>.Create(items, totalItems, page, size);
    }

    public async Task<IEnumerable<Product>> GetAllAsync(int page, int size, string order, CancellationToken cancellationToken = default)
    {
        IQueryable<Product> query = _context.Products
            .Include(p => p.Category)
            .Include(p => p.Rating);

        if (!string.IsNullOrWhiteSpace(order))
            query = ApplyOrdering(query, order);

        query = query
            .Skip((page - 1) * size)
            .Take(size);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Products.CountAsync(cancellationToken);
    }

    private IQueryable<Product> ApplyOrdering(IQueryable<Product> query, string order)
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
