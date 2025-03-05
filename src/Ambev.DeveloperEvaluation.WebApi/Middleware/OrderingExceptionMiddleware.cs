using Ambev.DeveloperEvaluation.Common.Exceptions;
using Ambev.DeveloperEvaluation.WebApi.Common;
using System.Text.Json;

namespace Ambev.DeveloperEvaluation.WebApi.Middleware;

public class OrderingExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public OrderingExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (OrderingException ex)
        {
            await HandleOrderingExceptionAsync(context, ex);
        }
    }

    private static Task HandleOrderingExceptionAsync(HttpContext context, OrderingException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status400BadRequest;

        var response = new ApiResponse
        {
            Success = false,
            Message = "Validation Failed",
            Errors = [ new() {
                Detail = exception.Message,
                Error = "Something went wrong, see details for explanation"
            }]
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(
            response,
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })
        );
    }
}
