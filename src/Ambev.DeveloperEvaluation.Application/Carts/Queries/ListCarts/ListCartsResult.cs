namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.ListCarts;

public class ListCartsResult
{
    public List<CartDto> Data { get; set; } = new();
    public int TotalItems { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}
public class CartDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<CartItemListDto> Products { get; set; } = new();
}
public class CartItemListDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
