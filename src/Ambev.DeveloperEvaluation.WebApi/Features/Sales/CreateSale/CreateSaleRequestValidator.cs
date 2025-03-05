using Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleRequestValidator()
    {
        RuleFor(sale => sale.SaleNumber).NotEmpty().NotNull().Length(1, 50);
        RuleFor(sale => sale.TotalAmount).NotEmpty().NotEqual(0);
        RuleFor(x => x.Items)
            .NotEmpty()
            .Must(items => items != null && items.Any())
            .ForEach(item => item.SetValidator(new SaleItemDtoValidator()));
    }
}
