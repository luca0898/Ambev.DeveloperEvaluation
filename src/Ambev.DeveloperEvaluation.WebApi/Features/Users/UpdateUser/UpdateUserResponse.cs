using Ambev.DeveloperEvaluation.Common.Validation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser;

public class UpdateUserResponse
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;
    public List<ValidationErrorDetail>? Errors { get; set; }
}
