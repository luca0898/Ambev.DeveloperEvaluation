using Ambev.DeveloperEvaluation.Application.Commons;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetAllCarts;

public class GetAllCartsHandler(ICartRepository repository, IMapper mapper) : IRequestHandler<GetAllCartsQuery, PaginatedResult<GetAllCartsResult>>
{
    public async Task<PaginatedResult<GetAllCartsResult>> Handle(GetAllCartsQuery request, CancellationToken cancellationToken)
    {
        var cart = await repository.GetAllAsync(request.Page, request.Size, request.Order, cancellationToken);

        var totalItems = await repository.CountAsync(cancellationToken);

        return new PaginatedResult<GetAllCartsResult>
        {
            Items = mapper.Map<List<GetAllCartsResult>>(cart),
            TotalItems = totalItems,
            PageNumber = request.Page,
            PageSize = request.Size
        };
    }
}
