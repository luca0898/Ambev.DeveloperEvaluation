namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomerByUserId;

public class GetCustomerByUserIdResponse
{
    public Guid Id { get; set; }
    public string ExternalId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}

