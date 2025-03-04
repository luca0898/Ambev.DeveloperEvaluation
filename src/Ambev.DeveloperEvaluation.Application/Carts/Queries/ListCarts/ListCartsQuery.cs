using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.ListCarts;

public class ListCartsQuery : IRequest<ListCartsResult>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string? OrderBy { get; set; }
    public ListCartsQuery(int page = 1, int pageSize = 10, string? orderBy = null)
    {
        Page = page > 0 ? page : 1;
        PageSize = pageSize > 0 ? pageSize : 10;
        OrderBy = orderBy;
    }
}
