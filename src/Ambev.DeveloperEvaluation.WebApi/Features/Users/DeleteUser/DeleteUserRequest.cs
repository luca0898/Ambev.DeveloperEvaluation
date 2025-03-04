namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.DeleteUser;

public class DeleteUserRequest
{
    /// <summary>
    /// The unique identifier of the user to delete
    /// </summary>
    public Guid Id { get; set; }
}
