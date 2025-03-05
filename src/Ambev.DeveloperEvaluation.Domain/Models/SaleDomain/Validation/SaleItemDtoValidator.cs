using Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Dtos;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Validation;

public class SaleItemDtoValidator : AbstractValidator<SaleItemDto>
{
    public SaleItemDtoValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty();

        RuleFor(x => x.Quantity).GreaterThan(0);

        RuleFor(x => x.UnitPrice).GreaterThan(0);
    }
}
