using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Categories.GetCategories;

public class GetCategoryQueryHandler(ICategoryRepository _categoryRepository, IMapper _mapper) : IRequestHandler<GetCategoryQuery, GetCategoryResult?>
{
    public async Task<GetCategoryResult?> Handle(GetCategoryQuery command, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(command.Id, cancellationToken);
        _ = category ?? throw new KeyNotFoundException($"Category with id {command.Id} not found");

        return _mapper.Map<GetCategoryResult>(category);
    }
}
