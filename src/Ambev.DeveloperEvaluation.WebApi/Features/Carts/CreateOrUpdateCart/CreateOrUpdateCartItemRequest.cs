namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateOrUpdateCart
{
    public class CartItemRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
