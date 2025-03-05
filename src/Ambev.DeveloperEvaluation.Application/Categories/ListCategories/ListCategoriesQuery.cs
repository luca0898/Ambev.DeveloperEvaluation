using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Categories.ListCategories
{
    public record ListCategoriesQuery(int Page, int Size, string? Order = null) : IRequest<ListCategoriesResult>;
}
