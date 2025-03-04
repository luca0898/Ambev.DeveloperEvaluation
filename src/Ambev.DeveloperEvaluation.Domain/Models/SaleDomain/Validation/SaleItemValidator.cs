using Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Validation;

public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty();

        RuleFor(x => x.Quantity).GreaterThan(0);

        RuleFor(x => x.UnitPrice).GreaterThan(0);
    }
}
