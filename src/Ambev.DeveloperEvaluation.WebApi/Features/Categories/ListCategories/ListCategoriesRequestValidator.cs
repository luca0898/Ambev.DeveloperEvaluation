using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.ListCategories;

public class ListCategoriesRequestValidator : AbstractValidator<ListCategoriesRequest>
{
    public ListCategoriesRequestValidator()
    {
        RuleFor(request => request.Page).GreaterThanOrEqualTo(1);

        RuleFor(request => request.Size).GreaterThanOrEqualTo(1).LessThanOrEqualTo(100);

        RuleFor(request => request.Order).NotEmpty().When(request => !string.IsNullOrEmpty(request.Order));
    }
}
