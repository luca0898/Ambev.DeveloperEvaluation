using Ambev.DeveloperEvaluation.Application.Commons;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetAllCarts;

public class GetAllCartsQuery : IRequest<PaginatedResult<GetAllCartsResult>>
{
    public int Page { get; set; }
    public int Size { get; set; }
    public string Order { get; set; } = string.Empty;
}