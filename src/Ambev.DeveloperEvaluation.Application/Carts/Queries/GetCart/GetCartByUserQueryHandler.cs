using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCart;

public class GetCartByUserQueryHandler(ICartRepository cartRepository, IMapper mapper)
: IRequestHandler<GetCartByUserQuery, GetCartResult>
{
    public async Task<GetCartResult> Handle(GetCartByUserQuery query, CancellationToken cancellationToken)
    {
        var sale = await cartRepository.GetByUserIdAsync(query.UserId, cancellationToken)
            ?? throw new KeyNotFoundException($"Cart for user ID {query.UserId} not found.");

        return mapper.Map<GetCartResult>(sale);
    }
}
