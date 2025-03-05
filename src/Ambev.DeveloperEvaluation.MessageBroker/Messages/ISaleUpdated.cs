using Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Dtos;
using Ambev.DeveloperEvaluation.MessageBroker.Common;

namespace Ambev.DeveloperEvaluation.MessageBroker.Messages
{
    public interface ISaleUpdated : IMessageResponse
    {
        public SaleDto Sale { get; set; }
    }
}
