using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Domain.Common;

public static class IQueryableExtensions
{
    public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> source, string propertyName)
    {
        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(parameter, propertyName);
        var selector = Expression.Lambda(property, parameter);
        return source.Provider.CreateQuery<T>(Expression.Call(typeof(Queryable), "OrderBy", [typeof(T), property.Type], source.Expression, selector));
    }

    public static IQueryable<T> OrderByDescendingDynamic<T>(this IQueryable<T> source, string propertyName)
    {
        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(parameter, propertyName);
        var selector = Expression.Lambda(property, parameter);
        return source.Provider.CreateQuery<T>(Expression.Call(typeof(Queryable), "OrderByDescending", [typeof(T), property.Type], source.Expression, selector));
    }
}
