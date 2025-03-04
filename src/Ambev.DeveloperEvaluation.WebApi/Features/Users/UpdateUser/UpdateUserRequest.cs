using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Common;
using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser;

public class UpdateUserRequest
{
    public string? Email { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public NameDto Name { get; set; } = new NameDto();
    public AddressDto Address { get; set; } = new AddressDto();
    public string? Phone { get; set; }
    public UserStatus Status { get; set; }
    public UserRole Role { get; set; }
}

