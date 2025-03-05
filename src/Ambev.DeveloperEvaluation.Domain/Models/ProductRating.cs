using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Models;

public class ProductRating : BaseEntity
{
    public double Rate { get; set; }
    public int Count { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}
