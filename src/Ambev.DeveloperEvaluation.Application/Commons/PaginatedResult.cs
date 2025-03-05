﻿namespace Ambev.DeveloperEvaluation.Application.Commons;

public class PaginatedResult<T>
{
    public List<T> Items { get; set; } = new();
    public int TotalItems { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
