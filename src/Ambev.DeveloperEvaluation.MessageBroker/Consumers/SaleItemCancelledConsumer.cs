﻿using Ambev.DeveloperEvaluation.MessageBroker.Messages;
using MassTransit;

namespace Ambev.DeveloperEvaluation.MessageBroker.Consumers
{
    public class SaleItemCancelledConsumer : IConsumer<IItemCancelled>
    {
        public async Task Consume(ConsumeContext<IItemCancelled> context)
        {
            Console.WriteLine("Message received at consumer");
            await Task.CompletedTask;
        }
    }
}
