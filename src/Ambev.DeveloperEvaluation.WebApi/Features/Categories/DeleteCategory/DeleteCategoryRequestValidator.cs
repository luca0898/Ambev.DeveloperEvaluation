using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.DeleteCategory;

public class DeleteCategoryRequestValidator : AbstractValidator<DeleteCategoryRequest>
{
    public DeleteCategoryRequestValidator()
    {
        RuleFor(request => request.Id).NotEmpty();
    }
}
