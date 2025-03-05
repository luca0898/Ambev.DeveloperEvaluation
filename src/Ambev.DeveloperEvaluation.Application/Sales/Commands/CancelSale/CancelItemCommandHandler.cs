using Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSale;

public class CancelItemCommandHandler(ISaleRepository saleRepository, IMediator mediator) : IRequestHandler<CancelItemCommand, bool>
{
    public async Task<bool> Handle(CancelItemCommand command, CancellationToken cancellationToken)
    {
        var sale = await saleRepository.GetByIdAsync(command.SaleId, cancellationToken);
        _ = sale ?? throw new KeyNotFoundException($"Sale with ID {command.SaleId} not found.");

        var item = sale.Items.FirstOrDefault(i => i.Id == command.ItemId);
        _ = item ?? throw new KeyNotFoundException($"Item with ID {command.ItemId} not found in sale.");

        sale.CancelItem(command.ItemId);

        await saleRepository.UpdateAsync(sale, cancellationToken);

        await mediator.Publish(new ItemCancelledEvent(sale, item), cancellationToken);

        return true;
    }
}
