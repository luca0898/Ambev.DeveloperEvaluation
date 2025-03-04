using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.GetCategory;

public class GetCategoryRequestValidator : AbstractValidator<GetCategoryRequest>
{
    public GetCategoryRequestValidator()
    {
        RuleFor(request => request.Id).NotEmpty();
    }
}
