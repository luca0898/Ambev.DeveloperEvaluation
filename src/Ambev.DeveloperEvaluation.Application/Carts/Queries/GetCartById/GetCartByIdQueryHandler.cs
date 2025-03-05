using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCartById;

public class GetCartsHandler : IRequestHandler<GetCartByIdQuery, GetCartByIdResponse?>
{
    private readonly ICartRepository _repository;
    private readonly IMapper _mapper;

    public GetCartsHandler(ICartRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetCartByIdResponse?> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
    {
        var cart = await _repository.GetByIdAsync(request.Id, cancellationToken);
        return cart == null ? null : _mapper.Map<GetCartByIdResponse>(cart);
    }
}
