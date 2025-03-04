using Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Dtos;
using Ambev.DeveloperEvaluation.MessageBroker.Common;

namespace Ambev.DeveloperEvaluation.MessageBroker.Messages
{
    public interface IItemCancelled : IMessageResponse
    {
        public SaleItemDto Item { get; set; }
    }
}
