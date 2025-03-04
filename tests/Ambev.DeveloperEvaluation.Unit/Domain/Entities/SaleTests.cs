using Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleTests
    {
        [Fact(DisplayName = "Given a valid Sale When adding items Then total amount is calculated correctly")]
        public void AddItem_ShouldCalculateTotalAmount()
        {
            var sale = SaleTestData.GenerateValidSale(0);
            var item = SaleTestData.GenerateSaleItem(5);

            sale.AddItem(new SaleItem(item.Quantity, item.UnitPrice, item.ProductId, sale.Id));

            sale.TotalAmount.Should().Be(item.Total);
        }

        [Fact(DisplayName = "Given a Sale When cancelling Then Sale is marked as cancelled")]
        public void Cancel_ShouldMarkSaleAsCancelled()
        {
            var sale = SaleTestData.GenerateValidSale();

            sale.Cancel();

            sale.IsCancelled.Should().BeTrue();
        }

        [Fact(DisplayName = "Given a Sale with one item When cancelling the item Then Sale is also cancelled")]
        public void CancelItem_LastItem_ShouldCancelSale()
        {
            var sale = SaleTestData.GenerateValidSale(1);
            var itemId = sale.Items.First().Id;

            sale.CancelItem(itemId);

            sale.IsCancelled.Should().BeTrue();
        }

        [Fact(DisplayName = "Given a SaleItem When adding more than 20 items Then exception is thrown")]
        public void AddItem_ExceedMaxQuantity_ShouldThrowException()
        {
            var sale = SaleTestData.GenerateValidSale(0);

            var action = () => sale.AddItem(new SaleItem(21, 50m, Guid.NewGuid(), sale.Id));

            action.Should().Throw<InvalidOperationException>()
                .WithMessage("Cannot sell more than 20 identical items.");
        }

        [Fact(DisplayName = "Given a SaleItem with 3 quantity When calculating discount Then no discount is applied")]
        public void CalculateDiscount_LessThanFourItems_ShouldApplyNoDiscount()
        {
            var item = SaleTestData.GenerateSaleItem(3);
            item.CalculateDiscount();
            item.Discount.Should().Be(0);
        }

        [Theory(DisplayName = "Given a SaleItem with valid quantities When calculating discount Then correct discount is applied")]
        [InlineData(4, 0.1)]
        [InlineData(10, 0.2)]
        public void CalculateDiscount_ValidQuantities_ShouldApplyCorrectDiscount(int quantity, decimal expectedDiscount)
        {
            var item = SaleTestData.GenerateSaleItem(quantity);

            item.CalculateDiscount();

            item.Discount.Should().Be(expectedDiscount);
        }
        [Fact(DisplayName = "Validation should pass for valid sale data")]
        public void Given_ValidSaleData_When_Validated_Then_ShouldReturnValid()
        {
            var sale = SaleTestData.GenerateValidSale();

            var result = sale.Validate();

            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }
    }
}
