namespace Ambev.DeveloperEvaluation.Application.Products.Queries.GetProductById
{
    //public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, GetProductsResponse>
    //{
    //    private readonly IApplicationDbContext _context;
    //    private readonly IMapper _mapper;

    //    public GetProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
    //    {
    //        _context = context;
    //        _mapper = mapper;
    //    }

    //    public async Task<GetProductsResponse> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    //    {
    //        var query = _context.Products.AsQueryable();

    //        // Apply filters
    //        foreach (var filter in request.Filters)
    //        {
    //            query = query.Where($"{filter.Key} == @0", filter.Value);
    //        }

    //        // Apply sorting
    //        if (!string.IsNullOrEmpty(request.Order))
    //        {
    //            query = query.OrderBy(request.Order);
    //        }

    //        // Pagination
    //        var totalItems = await query.CountAsync(cancellationToken);
    //        var totalPages = (int)Math.Ceiling(totalItems / (double)request.Size);

    //        var products = await query
    //            .Skip((request.Page - 1) * request.Size)
    //            .Take(request.Size)
    //            .ToListAsync(cancellationToken);

    //        return new GetProductsResponse(
    //            _mapper.Map<List<GetProductsProductDto>>(products),
    //            totalItems,
    //            totalPages
    //        );
    //    }
    //}
}
