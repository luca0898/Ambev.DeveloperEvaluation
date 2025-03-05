using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.ListSale
{
    public class ListSalesQueryHandler(ISaleRepository saleRepository, IMapper mapper)
    : IRequestHandler<ListSalesQuery, IEnumerable<GetSaleResult>>
    {
        public async Task<IEnumerable<GetSaleResult>> Handle(ListSalesQuery query, CancellationToken cancellationToken)
        {
            var sales = await saleRepository.GetAsync(cancellationToken);
            return mapper.Map<GetSaleResult[]>(sales);
        }
    }
}
