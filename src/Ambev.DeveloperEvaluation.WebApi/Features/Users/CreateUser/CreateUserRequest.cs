﻿using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Common;
using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

public class CreateUserRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserStatus Status { get; set; }
    public UserRole Role { get; set; }
    public NameDto Name { get; set; } = new NameDto();
    public AddressDto Address { get; set; } = new AddressDto();
}