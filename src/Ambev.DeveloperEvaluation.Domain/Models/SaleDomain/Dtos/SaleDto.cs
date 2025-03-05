namespace Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Dtos
{
    public sealed class SaleDto
    {
        public Guid Id { get; set; }
        public string SaleNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? BranchId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public IEnumerable<SaleItemDto>? Items { get; set; }

        public SaleDto()
        {
            Id = Guid.Empty;
            SaleNumber = string.Empty;
            TotalAmount = 0;
            IsCancelled = default;
            CustomerId = Guid.Empty;
            BranchId = Guid.Empty;
            CreatedAt = default;
            UpdatedAt = default;
            Items = default;
        }

        public SaleDto(
            Guid id,
            string saleNumber,
            decimal totalAmount,
            bool isCancelled,
            Guid? customerId,
            Guid? branchId,
            DateTime createdAt,
            DateTime? updatedAt,
            IEnumerable<SaleItemDto>? items)
        {
            Id = id;
            SaleNumber = saleNumber;
            TotalAmount = totalAmount;
            IsCancelled = isCancelled;
            CustomerId = customerId;
            BranchId = branchId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Items = items;
        }
    }
}