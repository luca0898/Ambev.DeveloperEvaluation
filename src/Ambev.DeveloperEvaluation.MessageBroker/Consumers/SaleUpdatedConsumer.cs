using Ambev.DeveloperEvaluation.MessageBroker.Messages;
using MassTransit;

namespace Ambev.DeveloperEvaluation.MessageBroker.Consumers
{
    public class SaleUpdatedConsumer : IConsumer<ISaleUpdated>
    {
        public async Task Consume(ConsumeContext<ISaleUpdated> context)
        {
            Console.WriteLine("Message received at consumer");
            await Task.CompletedTask;
        }
    }
}
