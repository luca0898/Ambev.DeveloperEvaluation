using Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSale;

public class CancelSaleCommandHandler(ISaleRepository saleRepository, IMediator mediator) : IRequestHandler<CancelSaleCommand, bool>
{
    public async Task<bool> Handle(CancelSaleCommand command, CancellationToken cancellationToken)
    {
        var sale = await saleRepository.GetByIdAsync(command.SaleId, cancellationToken);
        _ = sale ?? throw new KeyNotFoundException($"Sale with ID {command.SaleId} not found.");

        sale.Cancel();

        await saleRepository.UpdateAsync(sale, cancellationToken);

        await mediator.Publish(new SaleCancelledEvent(sale), cancellationToken);

        return true;
    }
}
