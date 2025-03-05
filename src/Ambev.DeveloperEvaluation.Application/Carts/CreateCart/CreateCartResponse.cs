namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public record CreateCartResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<CreateCartItemDto> Products { get; set; } = [];
}
