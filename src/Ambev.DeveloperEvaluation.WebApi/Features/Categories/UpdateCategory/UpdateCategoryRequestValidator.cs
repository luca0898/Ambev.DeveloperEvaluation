using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.UpdateCategory;

public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryRequestValidator()
    {
        RuleFor(request => request.Name).NotEmpty().MaximumLength(100);

        RuleFor(request => request.Description).MaximumLength(500);
    }
}
