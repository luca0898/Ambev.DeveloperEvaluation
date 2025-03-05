namespace Ambev.DeveloperEvaluation.MessageBroker.Common
{
    public interface IMessageResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
