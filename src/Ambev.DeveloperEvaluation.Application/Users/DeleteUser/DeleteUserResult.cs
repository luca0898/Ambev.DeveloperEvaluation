using Ambev.DeveloperEvaluation.Common.Validation;

namespace Ambev.DeveloperEvaluation.Application.Users.DeleteUser;

public class DeleteUserResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<ValidationErrorDetail>? Errors { get; set; }

}
