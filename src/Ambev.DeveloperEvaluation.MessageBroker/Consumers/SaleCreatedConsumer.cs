using Ambev.DeveloperEvaluation.MessageBroker.Messages;
using MassTransit;

namespace Ambev.DeveloperEvaluation.MessageBroker.Consumers
{
    public class SaleCreatedConsumer : IConsumer<ISaleCreated>
    {
        public async Task Consume(ConsumeContext<ISaleCreated> context)
        {
            Console.WriteLine("Message received at consumer");
            await Task.CompletedTask;
        }
    }
}
