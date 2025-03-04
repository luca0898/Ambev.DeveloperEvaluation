using Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Dtos;
using Ambev.DeveloperEvaluation.MessageBroker.Common;

namespace Ambev.DeveloperEvaluation.MessageBroker.Messages
{
    public interface ISaleCreated : IMessageResponse
    {
        public SaleDto Sale { get; set; }
    }
}
