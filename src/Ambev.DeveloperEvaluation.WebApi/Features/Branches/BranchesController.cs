using Ambev.DeveloperEvaluation.Application.Branches.Commands.DeleteBranch;
using Ambev.DeveloperEvaluation.Application.Branches.Commands.UpdateBranch;
using Ambev.DeveloperEvaluation.Application.Branches.Queries.GetBranch;
using Ambev.DeveloperEvaluation.Application.Branches.Queries.ListBranches;
using Ambev.DeveloperEvaluation.Application.Branchs.Commands.CreateBranch;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch;
using Ambev.DeveloperEvaluation.WebApi.Features.Branches.DeleteBranch;
using Ambev.DeveloperEvaluation.WebApi.Features.Branches.GetBranch;
using Ambev.DeveloperEvaluation.WebApi.Features.Branches.ListBranches;
using Ambev.DeveloperEvaluation.WebApi.Features.Branches.UpdateBranch;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches;

[ApiController]
[Route("api/[controller]")]
public class BranchesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public BranchesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponseWithData<ListBranchesResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ListBranches([FromQuery] ListBranchesRequest request, CancellationToken cancellationToken)
    {
        var validator = new ListBranchesRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return BadRequest(new ApiResponse
            {
                Success = false,
                Message = "Validation failed.",
                Errors = validationResult.Errors
                    .Select(error => (ValidationErrorDetail)error)
                    .ToList()
            });
        }

        var query = new ListBranchesQuery(request.Page, request.Size, request.Order);
        var result = await _mediator.Send(query, cancellationToken);

        return Ok(new ApiResponseWithData<ListBranchesResult>
        {
            Success = true,
            Message = "Branches retrieved successfully.",
            Data = result
        });
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetBranchResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBranch(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetBranchQuery(id);
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
        {
            return NotFound(new ApiResponse { Success = false, Message = "Category not found." });
        }

        return Ok(new ApiResponseWithData<GetBranchResponse>
        {
            Success = true,
            Message = "Branch retrieved successfully.",
            Data = _mapper.Map<GetBranchResponse>(result)
        });
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateBranchResponse>), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateBranch([FromBody] CreateBranchRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateBranchRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return BadRequest(new ApiResponse
            {
                Success = false,
                Message = "Validation failed.",
                Errors = validationResult.Errors
                    .Select(error => (ValidationErrorDetail)error)
                    .ToList()
            });
        }

        var command = _mapper.Map<CreateBranchCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateBranchResponse>
        {
            Success = true,
            Message = "Branch created successfully.",
            Data = _mapper.Map<CreateBranchResponse>(result)
        });
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateBranchResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateBranch(Guid id, [FromBody] UpdateBranchRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<UpdateBranchCommand>(request) with { Id = id };
        var result = await _mediator.Send(command, cancellationToken);

        if (result == null)
        {
            return NotFound(new ApiResponse
            {
                Success = false,
                Message = $"Branch with ID {id} not found."
            });
        }

        return Ok(new ApiResponseWithData<UpdateBranchResult>
        {
            Success = true,
            Message = "Branch updated successfully.",
            Data = result
        });
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBranch([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteBranchRequest { Id = id };
        var validator = new DeleteBranchRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return BadRequest(new ApiResponse
            {
                Success = false,
                Message = "Invalid request data.",
                Errors = validationResult.Errors.Select(error => (ValidationErrorDetail)error).ToList()
            });
        }

        var command = _mapper.Map<DeleteBranchCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);

        if (!result.Success)
        {
            return NotFound(new ApiResponse
            {
                Success = false,
                Message = "Branch not found."
            });
        }

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Branch deleted successfully."
        });
    }
}
