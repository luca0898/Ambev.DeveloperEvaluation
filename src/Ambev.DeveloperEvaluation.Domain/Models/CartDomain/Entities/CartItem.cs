using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Models.CartDomain.Entities
{
    public class CartItem : BaseEntity
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public Guid CartId { get; set; }
        public Cart Cart { get; }

        public void UpdateQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new InvalidOperationException("Quantity must be greater than zero.");
            Quantity = quantity;
        }

        public void Update(CartItem itemScreen)
        {
            ProductId = itemScreen.ProductId;
            Quantity = itemScreen.Quantity;
        }
    }
}
