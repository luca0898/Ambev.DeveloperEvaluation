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
    }
}