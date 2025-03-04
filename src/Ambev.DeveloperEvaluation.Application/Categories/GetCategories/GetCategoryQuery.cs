using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Categories.GetCategories;

public record GetCategoryQuery(Guid Id) : IRequest<GetCategoryResult>;
