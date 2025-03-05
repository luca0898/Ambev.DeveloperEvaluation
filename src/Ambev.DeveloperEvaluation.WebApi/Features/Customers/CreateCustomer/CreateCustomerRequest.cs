namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer
{
    public sealed record CreateCustomerRequest(Guid UserId, string ExternalId);
}
