using Ambev.DeveloperEvaluation.MessageBroker.Common;

namespace Ambev.DeveloperEvaluation.MessageBroker.Messages
{
    public interface ISaleDeleted : IMessageResponse
    {
        public string SaleNumber { get; set; }
    }
}
