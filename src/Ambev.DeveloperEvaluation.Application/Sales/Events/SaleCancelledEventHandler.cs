using Ambev.DeveloperEvaluation.Application.Abstractions.Messaging;
using Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Events;
using Ambev.DeveloperEvaluation.MessageBroker.Common;
using Ambev.DeveloperEvaluation.MessageBroker.Messages;
using MassTransit;

namespace Ambev.DeveloperEvaluation.Application.Sales.Events;

public class SaleCancelledEventHandler(IPublishEndpoint publishEndpoint) : IDomainEventHandler<SaleCancelledEvent>
{
    public async Task Handle(SaleCancelledEvent notification, CancellationToken cancellationToken)
    {
        try
        {
            await publishEndpoint.Publish<IItemCancelled>(new { notification.Sale }, cancellationToken);
        }
        catch (Exception ex)
        {
            await publishEndpoint.Publish<IMessageResponse>(new
            {
                Success = false,
                Message = $"{ex.Message}-{ex.InnerException?.Message}"
            }, cancellationToken);
            throw;
        }
    }
}
