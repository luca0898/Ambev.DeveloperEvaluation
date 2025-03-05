using MediatR;
using Ambev.DeveloperEvaluation.Domain.Models;
using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Commons;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts
{
    public class GetAllProductsHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<GetAllProductsQuery, PaginatedResult<GetAllProductsResult>>
    {
        public async Task<PaginatedResult<GetAllProductsResult>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllAsync(request.Page, request.Size, request.Order, cancellationToken);

            var totalUsers = await productRepository.CountAsync(cancellationToken);

            return new PaginatedResult<GetAllProductsResult>
            {
                Items = mapper.Map<List<GetAllProductsResult>>(products),
                TotalItems = totalUsers,
                PageNumber = request.Page,
                PageSize = request.Size
            };
        }
    }
}
