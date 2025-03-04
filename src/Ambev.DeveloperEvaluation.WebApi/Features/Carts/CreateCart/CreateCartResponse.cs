using Ambev.DeveloperEvaluation.WebApi.Features.Carts.DTOs;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    public class CreateCartResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CartItemDto> Products { get; set; } = [];
    }
}
