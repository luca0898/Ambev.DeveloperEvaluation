using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using Ambev.DeveloperEvaluation.Application.Users.GetAllUsers;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Application.Users.UpdateUser;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.DeleteUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetAllUsers;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users;

[ApiController]
[Route("api/[controller]")]
public class UsersController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public UsersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateUserResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateUserRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return BadRequest(new ApiResponseWithData<object>
            {
                Success = false,
                Message = "Validation failed",
                Data = validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }).ToList()
            });
        }

        var command = _mapper.Map<CreateUserCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateUserResponse>
        {
            Success = true,
            Message = "User created successfully",
            Data = _mapper.Map<CreateUserResponse>(response)
        });
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateUserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserRequest request,
        CancellationToken cancellationToken)
    {
        var validator = new UpdateUserRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return BadRequest(new ApiResponse
            {
                Success = false,
                Message = "Validation failed",
                Errors = validationResult.Errors.Select(error => new ValidationErrorDetail
                {
                    PropertyName = error.PropertyName,
                    ErrorMessage = error.ErrorMessage
                }).ToList()
            });
        }

        var command = _mapper.Map<UpdateUserCommand>(request);
        command.Id = id;

        var response = await _mediator.Send(command, cancellationToken);

        if (response is null)
            return NotFound(new ApiResponse { Success = false, Message = $"User with ID {id} not found." });

        return Ok(new ApiResponseWithData<UpdateUserResponse>
        {
            Success = true,
            Message = "User updated successfully",
            Data = _mapper.Map<UpdateUserResponse>(response)
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetUserRequest { Id = id };
        var validator = new GetUserRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetUserQuery>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetUserResponse>
        {
            Success = true,
            Message = "User retrieved successfully",
            Data = _mapper.Map<GetUserResponse>(response)
        });
    }

    [HttpGet]
    [ProducesResponseType(typeof(PaginatedResponse<GetAllUsersResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllUsers(
        [FromQuery(Name = "_page")] int page = 1,
        [FromQuery(Name = "_size")] int size = 10,
        [FromQuery(Name = "_order")] string order = "",
        CancellationToken cancellationToken = default)
    {
        GetAllUsersRequest request = new GetAllUsersRequest
        {
            Page = page,
            Size = size,
            Order = order
        };
        var validator = new GetAllUsersRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetAllUsersQuery>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new
        {
            Data = response.Items,
            CurrentPage = response.PageNumber,
            response.TotalItems,
            TotalPages = (int)Math.Ceiling(response.TotalItems / (double)size),
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteUserRequest { Id = id };
        var validator = new DeleteUserRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return BadRequest(new ApiResponse
            {
                Success = false,
                Message = "Validation failed",
                Errors = validationResult.Errors.Select(error => new ValidationErrorDetail
                {
                    PropertyName = error.PropertyName,
                    ErrorMessage = error.ErrorMessage
                }).ToList()
            });
        }

        var command = _mapper.Map<DeleteUserCommand>(request.Id);
        var result = await _mediator.Send(command, cancellationToken);

        if (!result.Success)
        {
            return NotFound(new ApiResponse
            {
                Success = false,
                Message = result.Message
            });
        }

        return OK(new ApiResponse
        {
            Success = true,
            Message = "User deleted successfully"
        });
    }
}
