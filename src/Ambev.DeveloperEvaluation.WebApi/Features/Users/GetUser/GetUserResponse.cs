using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Common;
using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;

public class GetUserResponse
{
    /// <summary>
    /// The unique identifier of the user
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The user's email address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The user's username
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// The user's password
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// The user's full name details
    /// </summary>
    public NameDto Name { get; set; } = new NameDto();

    /// <summary>
    /// The user's address details
    /// </summary>
    public AddressDto Address { get; set; } = new AddressDto();

    /// <summary>
    /// The user's phone number
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// The current status of the user
    /// </summary>
    public UserStatus Status { get; set; }

    /// <summary>
    /// The user's role in the system
    /// </summary>
    public UserRole Role { get; set; }
}

