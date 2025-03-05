namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomerByUserId;

public class GetCustomerByUserIdResult
{
    public Guid Id { get; set; }
    public string ExternalId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}
