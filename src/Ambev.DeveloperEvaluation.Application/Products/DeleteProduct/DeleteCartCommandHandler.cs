using Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct
{
    public class DeleteCartCommandHandler(ICartRepository _repository) : IRequestHandler<DeleteCartCommand, bool>
    {
        public async Task<bool> Handle(DeleteCartCommand command, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(command.Id, cancellationToken);
        }
    }
}
