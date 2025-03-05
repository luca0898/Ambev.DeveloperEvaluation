namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts;

public class GetAllProductsResult
{
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public GetAllProductRating Rating { get; set; }
}

public class GetAllProductRating
{
    public GetAllProductRating(double rating, int count)
    {
        Rating = rating;
        Count = count;
    }

    public double Rating { get; set; }
    public int Count { get; set; }
}
