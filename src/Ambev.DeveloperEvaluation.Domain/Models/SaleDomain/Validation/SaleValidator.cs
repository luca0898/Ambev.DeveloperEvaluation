using Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.SaleNumber).NotEmpty().NotNull().Length(1, 50);
        RuleFor(sale => sale.TotalAmount).NotEmpty().NotEqual(0);
        RuleFor(x => x.Items)
            .NotEmpty()
            .Must(items => items != null && items.Count != 0)
            .ForEach(item => item.SetValidator(new SaleItemValidator()));
    }
}
