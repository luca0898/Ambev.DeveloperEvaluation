using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Models;

public class Product : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public ProductRating Rating { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public Product()
    {

    }

    public Product(
        string title,
        decimal price,
        string description,
        string image,
        ProductRating rating,
        Guid categoryId)
    {
        Title = title;
        Price = price;
        Description = description;
        Image = image;
        Rating = rating;
        CategoryId = categoryId;
    }
}
