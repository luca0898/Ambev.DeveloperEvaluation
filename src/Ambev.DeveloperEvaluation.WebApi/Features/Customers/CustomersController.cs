using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.Application.Customers.GetCustomerByUserId;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomerByUserId;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController(IMediator mediator, IMapper mapper) : BaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateCustomerResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateCustomerRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = mapper.Map<CreateCustomerCommand>(request);
            var response = await mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateCustomerResponse>
            {
                Success = true,
                Message = "Customer created successfully",
                Data = mapper.Map<CreateCustomerResponse>(response)
            });
        }
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseWithData<GetCustomerByUserIdResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomerByUserId([FromQuery, Required] Guid userId, CancellationToken cancellationToken)
        {
            var request = new GetCustomerByUserIdRequest(userId);
            var validator = new GetCustomerByUserIdRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var response = await mediator.Send(mapper.Map<GetCustomerByUserIdCommand>(request), cancellationToken);

            if (response == null)
                return NotFound();

            return OK(mapper.Map<GetCustomerByUserIdResponse>(response));
        }
    }
}
