using Ambev.DeveloperEvaluation.Domain.Models;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Categories.CreateCategory;

public class CreateCategoryCommandHandler(ICategoryRepository _categoryRepository, IMapper _mapper) : IRequestHandler<CreateCategoryCommand, CreateCategoryResult>
{
    public async Task<CreateCategoryResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);

        var createdCategory = await _categoryRepository.CreateAsync(category, cancellationToken);

        return _mapper.Map<CreateCategoryResult>(createdCategory);
    }
}
