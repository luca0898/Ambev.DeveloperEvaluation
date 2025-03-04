﻿using Ambev.DeveloperEvaluation.Application.Products.DTOs;
using Ambev.DeveloperEvaluation.Domain.Models;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryProfile : Profile
    {
        public GetProductsByCategoryProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
