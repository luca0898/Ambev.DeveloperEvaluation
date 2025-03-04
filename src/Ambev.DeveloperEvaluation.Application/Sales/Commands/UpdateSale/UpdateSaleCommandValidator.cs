using Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.UpdateSale;

public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
{
    public UpdateSaleCommandValidator()
    {
        RuleFor(sale => sale.Id).NotEmpty();

        RuleFor(sale => sale.SaleNumber).NotEmpty().NotNull().Length(1, 50);

        RuleFor(sale => sale.TotalAmount).NotEmpty().GreaterThan(0);

        RuleFor(x => x.Items)
            .NotEmpty()
            .Must(items => items != null && items.Any())
            .ForEach(item => item.SetValidator(new SaleItemDtoValidator()));
    }
}
