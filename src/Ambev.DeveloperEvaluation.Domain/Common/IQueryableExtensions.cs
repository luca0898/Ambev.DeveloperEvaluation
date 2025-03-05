using Ambev.DeveloperEvaluation.Common.Exceptions;
using System.Linq.Expressions;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.Domain.Common;

public static class IQueryableExtensions
{
    public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> source, string propertyName)
    {
        var propertyInfo = typeof(T).GetProperty(
            propertyName,
            BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance
        );
        if (propertyInfo == null)
        {
            throw new OrderingException($"Property '{propertyName}' does not exist on type {typeof(T).Name}.");
        }

        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(parameter, propertyInfo);
        var selector = Expression.Lambda(property, parameter);
        return source.Provider.CreateQuery<T>(
            Expression.Call(
                typeof(Queryable),
                "OrderBy",
                new Type[] { typeof(T), propertyInfo.PropertyType },
                source.Expression,
                Expression.Quote(selector)
            )
        );
    }

    public static IQueryable<T> OrderByDescendingDynamic<T>(this IQueryable<T> source, string propertyName)
    {
        var propertyInfo = typeof(T).GetProperty(
            propertyName,
            BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance
        );
        if (propertyInfo == null)
        {
            throw new OrderingException($"Property '{propertyName}' does not exist on type {typeof(T).Name}.");
        }

        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(parameter, propertyInfo);
        var selector = Expression.Lambda(property, parameter);
        return source.Provider.CreateQuery<T>(
            Expression.Call(
                typeof(Queryable),
                "OrderByDescending",
                new Type[] { typeof(T), propertyInfo.PropertyType },
                source.Expression,
                Expression.Quote(selector)
            )
        );
    }
}