namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.UpdateCart;

public class UpdateCartResult
{
    public Guid Id { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<CartItemResult> Products { get; set; } = new();
}
public class CartItemResult
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
