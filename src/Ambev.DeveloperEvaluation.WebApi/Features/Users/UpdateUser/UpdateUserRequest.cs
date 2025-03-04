using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Common;
using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser;

public class UpdateUserRequest
{
    /// <summary>
    /// Gets or sets the user's email address. Must be a valid email format.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the username. Must be unique and contain only valid characters.
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// Gets or sets the password. Must meet security requirements.
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Gets or sets the user's full name.
    /// </summary>
    public NameDto Name { get; set; } = new NameDto();

    /// <summary>
    /// Gets or sets the user's address details.
    /// </summary>
    public AddressDto Address { get; set; } = new AddressDto();

    /// <summary>
    /// Gets or sets the phone number in format (XX) XXXXX-XXXX.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Gets or sets the initial status of the user account.
    /// </summary>
    public UserStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the role assigned to the user.
    /// </summary>
    public UserRole Role { get; set; }
}

