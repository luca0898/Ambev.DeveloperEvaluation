using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Categories.CreateCategory;

public record CreateCategoryCommand(string Name, string Description) : IRequest<CreateCategoryResult>;
