using Ambev.DeveloperEvaluation.WebApi.Features.Carts.DTOs;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    public class CreateCartRequest
    {
        public Guid UserId { get; set; }
        public List<CartItemDto> Products { get; set; } = [];
    }
}
