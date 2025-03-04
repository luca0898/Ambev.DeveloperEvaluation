using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Entities;

public class Sale : BaseEntity
{
    public string SaleNumber { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public bool IsCancelled { get; set; } = false;
    public Guid? CustomerId { get; set; }
    public Guid? BranchId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public List<SaleItem> Items { get; set; } = [];

    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    public void Update(decimal totalAmount, bool isCancelled, Guid? customerId, Guid? branchId)
    {
        TotalAmount = totalAmount;
        IsCancelled = isCancelled;
        CustomerId = customerId;
        BranchId = branchId;
    }

    public void UpdateItems(SaleItem[] items)
    {
        Items.RemoveAll(x => items.All(itemScreen => itemScreen.ProductId != x.ProductId));

        foreach (var itemScreen in items)
        {
            var existingItem = Items.Find(item => item.ProductId == itemScreen.ProductId);

            if (existingItem is not null)
                existingItem.Update(itemScreen);
            else
                Items.Add(itemScreen);
        }

        Calculate();
        UpdateTimestamp();
    }

    public void Calculate()
    {
        TotalAmount = Items.Sum(item => item.Quantity);
        Items.ForEach(item => item.CalculateDiscount());
    }

    public void Cancel()
    {
        if (IsCancelled)
            throw new InvalidOperationException("Sale is already cancelled.");

        IsCancelled = true;
        UpdateTimestamp();
    }

    public void UpdateTimestamp()
    {
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddItem(SaleItem item)
    {
        Items.Add(item);
    }

    public void CancelItem(Guid itemId)
    {
        var item = Items.FirstOrDefault(i => i.Id == itemId);
        _ = item ?? throw new KeyNotFoundException($"Item with ID {itemId} not found.");

        Items.Remove(item);

        if (Items.Count == 0)
        {
            Cancel();
        }
        else
        {
            Calculate();
            UpdateTimestamp();
        }
    }
}
