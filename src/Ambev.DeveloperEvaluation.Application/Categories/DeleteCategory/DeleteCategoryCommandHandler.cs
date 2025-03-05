using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Categories.DeleteCategory;

public class DeleteCategoryCommandHandler(ICategoryRepository _categoryRepository) : IRequestHandler<DeleteCategoryCommand, DeleteCategoryResult>
{
    public async Task<DeleteCategoryResult> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(command.Id, cancellationToken);
        _ = category ?? throw new KeyNotFoundException($"Category with id {command.Id} not found");

        await _categoryRepository.DeleteAsync(category.Id, cancellationToken);

        return new DeleteCategoryResult { Success = true };
    }
}
