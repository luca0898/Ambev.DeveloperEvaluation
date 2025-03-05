namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public sealed record CreateOrUpdateCartResult
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<CreateCartItemDto>? Products { get; set; }
}
