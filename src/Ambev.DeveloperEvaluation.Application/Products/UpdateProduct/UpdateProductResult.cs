﻿using Ambev.DeveloperEvaluation.Application.Products.DTOs;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

public class UpdateProductResult
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public ProductRatingDto Rating { get; set; } = new ProductRatingDto(0, 0);
}
