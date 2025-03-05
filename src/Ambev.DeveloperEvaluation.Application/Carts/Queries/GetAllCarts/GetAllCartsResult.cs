namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetAllCarts;

public class GetAllCartsResult
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public List<GetAllCartsItemResult> Products { get; set; } = [];
}
public class GetAllCartsItemResult
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
