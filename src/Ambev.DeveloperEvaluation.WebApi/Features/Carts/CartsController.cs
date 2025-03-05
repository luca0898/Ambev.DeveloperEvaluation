using Ambev.DeveloperEvaluation.Application.Carts.Commands.UpdateCart;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCart;
using Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCartById;
using Ambev.DeveloperEvaluation.Application.Carts.Queries.ListCarts;
using Ambev.DeveloperEvaluation.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartsController : BaseController
    {
        private readonly IMediator _mediator;

        public CartsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseWithData<ListCartsResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCarts(
        [FromQuery] int _page = 1,
        [FromQuery] int _size = 10,
        [FromQuery] string? _order = null,
        CancellationToken cancellationToken = default)
        {
            var query = new ListCartsQuery(_page, _size, _order);
            var response = await _mediator.Send(query, cancellationToken);

            return OK(new ApiResponseWithData<ListCartsResult>
            {
                Success = true,
                Message = "Carts retrieved successfully",
                Data = response
            });
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateCartResult>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCart([FromBody] CreateCartCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Invalid request payload."
                });
            }

            var response = await _mediator.Send(command, cancellationToken);

            if (response == null)
                return BadRequest("Failed to create the cart. Please try again.");

            return CreatedAtAction(null, new { id = response.Id }, new ApiResponseWithData<CreateCartResult>
            {
                Success = true,
                Message = "Cart created successfully",
                Data = response
            });
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetCartResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCartById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetCartQuery(id);
            var response = await _mediator.Send(query, cancellationToken);

            return OK(new ApiResponseWithData<GetCartResult>
            {
                Success = true,
                Message = "Cart retrieved successfully",
                Data = response
            });
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponseWithData<UpdateCartResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCart(
            [FromRoute] Guid id,
            [FromBody] UpdateCartCommand command,
            CancellationToken cancellationToken)
        {
            command = command with { Id = id };
            var response = await _mediator.Send(command, cancellationToken);

            return OK(new ApiResponseWithData<UpdateCartResult>
            {
                Success = true,
                Message = "Cart updated successfully",
                Data = response
            });
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCart([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteCartCommand(id), cancellationToken);

            return OK(new ApiResponse
            {
                Success = true,
                Message = "Cart deleted successfully"
            });
        }
    }
}
