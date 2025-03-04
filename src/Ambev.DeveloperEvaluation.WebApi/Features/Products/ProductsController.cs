using Ambev.DeveloperEvaluation.Application.Products.Commands.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.Commands.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.Products.DTOs;
using Ambev.DeveloperEvaluation.Application.Products.Queries.GetProductCategories;
using Ambev.DeveloperEvaluation.Application.Products.Queries.GetProductsByCategory;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    //// GET /products
    //[HttpGet]
    //[ProducesResponseType(typeof(ApiResponseWithData<PaginatedResult<ProductDto>>), StatusCodes.Status200OK)]
    //public async Task<IActionResult> GetProducts(
    //    [FromQuery] int _page = 1,
    //    [FromQuery] int _size = 10,
    //    [FromQuery] string? _order = null,
    //    CancellationToken cancellationToken = default)
    //{
    //    var query = new GetProductsQuery
    //    {
    //        Page = _page,
    //        Size = _size,
    //        Order = _order
    //    };

    //    var result = await _mediator.Send(query, cancellationToken);

    //    return Ok(new ApiResponseWithData<PaginatedResult<ProductDto>>
    //    {
    //        Success = true,
    //        Message = "Products retrieved successfully.",
    //        Data = result
    //    });
    //}

    //// GET /products/{id}
    //[HttpGet("{id:int}")]
    //[ProducesResponseType(typeof(ApiResponseWithData<ProductDto>), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    //public async Task<IActionResult> GetProductById([FromRoute] int id, CancellationToken cancellationToken = default)
    //{
    //    var query = new GetProductByIdQuery { Id = id };
    //    var result = await _mediator.Send(query, cancellationToken);

    //    if (result == null)
    //    {
    //        return NotFound(new ApiResponse
    //        {
    //            Success = false,
    //            Message = "Product not found."
    //        });
    //    }

    //    return Ok(new ApiResponseWithData<ProductDto>
    //    {
    //        Success = true,
    //        Message = "Product retrieved successfully.",
    //        Data = result
    //    });
    //}

    /// <summary>
    ///     Creates a new customer
    /// </summary>
    /// <param name="request">The customer creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created customer details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request,
        CancellationToken cancellationToken)
    {
        var validator = new CreateProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateProductCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateProductResponse>
        {
            Success = true,
            Message = "Product created successfully",
            Data = _mapper.Map<CreateProductResponse>(response)
        });
    }

    // PUT /products/{id}
    //[HttpPut("{id:int}")]
    //[ProducesResponseType(typeof(ApiResponseWithData<ProductDto>), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    //public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductCommand command, CancellationToken cancellationToken = default)
    //{
    //    command.Id = id;
    //    var result = await _mediator.Send(command, cancellationToken);

    //    if (result == null)
    //    {
    //        return NotFound(new ApiResponse
    //        {
    //            Success = false,
    //            Message = "Product not found."
    //        });
    //    }

    //    return Ok(new ApiResponseWithData<ProductDto>
    //    {
    //        Success = true,
    //        Message = "Product updated successfully.",
    //        Data = result
    //    });
    //}

    // DELETE /products/{id}
    [HttpDelete("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var command = new DeleteProductCommand { Id = id };
        var result = await _mediator.Send(command, cancellationToken);

        if (!result)
        {
            return NotFound(new ApiResponse
            {
                Success = false,
                Message = "Product not found."
            });
        }

        return NoContent();
    }

    // GET /products/categories
    [HttpGet("categories")]
    [ProducesResponseType(typeof(ApiResponseWithData<List<string>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProductCategories(CancellationToken cancellationToken = default)
    {
        var query = new GetProductCategoriesQuery();
        var result = await _mediator.Send(query, cancellationToken);

        return Ok(new ApiResponseWithData<List<string>>
        {
            Success = true,
            Message = "Product categories retrieved successfully.",
            Data = result
        });
    }

    // GET /products/category/{category}
    [HttpGet("category/{category}")]
    [ProducesResponseType(typeof(ApiResponseWithData<PaginatedResult<ProductDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProductsByCategory(
        [FromRoute] string category,
        [FromQuery] int _page = 1,
        [FromQuery] int _size = 10,
        [FromQuery] string? _order = null,
        CancellationToken cancellationToken = default)
    {
        var query = new GetProductsByCategoryQuery
        {
            Category = category,
            Page = _page,
            Size = _size,
            Order = _order
        };

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(new ApiResponseWithData<PaginatedResult<ProductDto>>
        {
            Success = true,
            Message = "Products retrieved successfully.",
            Data = result
        });
    }
}
