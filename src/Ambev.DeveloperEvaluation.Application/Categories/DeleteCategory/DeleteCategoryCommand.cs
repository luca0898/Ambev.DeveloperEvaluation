using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Categories.DeleteCategory;

public record DeleteCategoryCommand(Guid Id) : IRequest<DeleteCategoryResult>;
