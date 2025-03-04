using Ambev.DeveloperEvaluation.WebApi.Features.Carts.DTOs;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart
{
    public class UpdateCartRequest
    {
        public List<CartItemDto> Products { get; set; } = new();
    }
}
