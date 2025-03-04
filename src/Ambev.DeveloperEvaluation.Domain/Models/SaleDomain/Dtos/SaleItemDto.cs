namespace Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Dtos
{
    public sealed class SaleItemDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalItemAmount { get; set; }
        public Guid ProductId { get; set; }

        public SaleItemDto()
        {
            Id = Guid.Empty;
            Quantity = 0;
            UnitPrice = 0;
            Discount = 0;
            TotalItemAmount = 0;
            ProductId = Guid.Empty;
        }

        public SaleItemDto(Guid id, int quantity, decimal unitPrice, decimal discount, decimal totalItemAmount, Guid productId)
        {
            Id = id;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = discount;
            TotalItemAmount = totalItemAmount;
            ProductId = productId;
        }
    }
}