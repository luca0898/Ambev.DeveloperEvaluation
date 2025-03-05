using Ambev.DeveloperEvaluation.Application.Categories.CreateCategory;
using Ambev.DeveloperEvaluation.Application.Categories.DeleteCategory;
using Ambev.DeveloperEvaluation.Application.Categories.GetCategories;
using Ambev.DeveloperEvaluation.Application.Categories.ListCategories;
using Ambev.DeveloperEvaluation.Application.Categories.UpdateCategory;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Categories.CreateCategory;
using Ambev.DeveloperEvaluation.WebApi.Features.Categories.DeleteCategory;
using Ambev.DeveloperEvaluation.WebApi.Features.Categories.GetCategory;
using Ambev.DeveloperEvaluation.WebApi.Features.Categories.ListCategories;
using Ambev.DeveloperEvaluation.WebApi.Features.Categories.UpdateCategory;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CategoriesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponseWithData<ListCategoriesResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ListCategories(
        [FromQuery] ListCategoriesRequest request,
        CancellationToken cancellationToken = default)
    {
        var validator = new ListCategoriesRequestValidator();
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

        var query = new ListCategoriesQuery(request.Page, request.Size, request.Order);
        var result = await _mediator.Send(query, cancellationToken);

        return Ok(new ApiResponseWithData<ListCategoriesResult>
        {
            Success = true,
            Message = "Categories retrieved successfully.",
            Data = result
        });
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetCategoryResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCategory(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetCategoryQuery(id);
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
        {
            return NotFound(new ApiResponse { Success = false, Message = "Category not found." });
        }

        return Ok(new ApiResponseWithData<GetCategoryResult>
        {
            Success = true,
            Message = "Category retrieved successfully.",
            Data = result
        });
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateCategoryResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCategory(
        [FromBody] CreateCategoryRequest request,
        CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateCategoryCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateCategoryResponse>
        {
            Success = true,
            Message = "Category created successfully.",
            Data = _mapper.Map<CreateCategoryResponse>(response)
        });
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateCategoryResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateCategory(
    Guid id,
    [FromBody] UpdateCategoryRequest request,
    CancellationToken cancellationToken)
    {
        var command = _mapper.Map<UpdateCategoryCommand>(request) with { Id = id };

        var result = await _mediator.Send(command, cancellationToken);
        var response = _mapper.Map<UpdateCategoryResponse>(result);

        return Ok(new ApiResponseWithData<UpdateCategoryResponse>
        {
            Success = true,
            Message = "Category updated successfully.",
            Data = response
        });
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCategory([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteCategoryRequest { Id = id };
        var validator = new DeleteCategoryRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return BadRequest(new ApiResponse
            {
                Success = false,
                Message = "Invalid request data.",
                Errors = validationResult.Errors
                .Select(error => (ValidationErrorDetail)error)
                .ToList()
            });
        }

        var command = _mapper.Map<DeleteCategoryCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);

        if (!result.Success)
        {
            return NotFound(new ApiResponse
            {
                Success = false,
                Message = $"Category with ID {id} not found."
            });
        }

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Category deleted successfully."
        });
    }
}
