namespace Ambev.DeveloperEvaluation.Application.Users.ListUser;

public class GetAllUsersRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Order { get; set; }
}
