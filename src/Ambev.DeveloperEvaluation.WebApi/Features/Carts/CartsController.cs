using Ambev.DeveloperEvaluation.Application.Carts.Commands.UpdateCart;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.Application.Carts.Queries.GetAllCarts;
using Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCart;
using Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCartById;
using Ambev.DeveloperEvaluation.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartsController(IMediator mediator) : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseWithData<GetAllCartsResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCarts(
            [FromQuery(Name = "_page")] int page = 1,
            [FromQuery(Name = "_size")] int size = 10,
            [FromQuery(Name = "_order")] string order = "",
            CancellationToken cancellationToken = default)
        {
            var query = new GetAllCartsQuery
            {
                Page = page,
                Size = size,
                Order = order
            };

            var response = await mediator.Send(query, cancellationToken);

            return Ok(new
            {
                Data = response.Items,
                CurrentPage = response.PageNumber,
                response.TotalItems,
                TotalPages = (int)Math.Ceiling(response.TotalItems / (double)size),
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

            var response = await mediator.Send(command, cancellationToken);

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
            var response = await mediator.Send(query, cancellationToken);

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
            var response = await mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<UpdateCartResult>
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
            await mediator.Send(new DeleteCartCommand(id), cancellationToken);

            return OK(new ApiResponse
            {
                Success = true,
                Message = "Cart deleted successfully"
            });
        }
    }
}
