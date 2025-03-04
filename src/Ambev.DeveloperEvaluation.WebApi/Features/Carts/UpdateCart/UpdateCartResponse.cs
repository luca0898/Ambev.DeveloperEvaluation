using Ambev.DeveloperEvaluation.WebApi.Features.Carts.DTOs;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart
{
    public class UpdateCartResponse
    {
        public Guid Id { get; set; }
        public List<CartItemDto> Products { get; set; } = new();
    }
}
