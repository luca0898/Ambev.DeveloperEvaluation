namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCartById;

public class GetCartByIdResult
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<CartItemResult> Products { get; set; } = new();
}
public class CartItemResult
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
