using Ambev.DeveloperEvaluation.MessageBroker.Messages;
using MassTransit;

namespace Ambev.DeveloperEvaluation.MessageBroker.Consumers
{
    public class SaleDeletedConsumer : IConsumer<ISaleDeleted>
    {
        public async Task Consume(ConsumeContext<ISaleDeleted> context)
        {
            Console.WriteLine("Message received at consumer");
            await Task.CompletedTask;
        }
    }
}
