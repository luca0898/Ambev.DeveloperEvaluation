using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Common;
using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Enums;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser;

public class UpdateUserResult
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public UserStatus Status { get; set; }
    public NameDto Name { get; set; } = new NameDto();
    public AddressDto Address { get; set; } = new AddressDto();
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
};