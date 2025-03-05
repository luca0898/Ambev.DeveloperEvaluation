namespace Ambev.DeveloperEvaluation.Application.Carts;

public class CartItemCommand
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
