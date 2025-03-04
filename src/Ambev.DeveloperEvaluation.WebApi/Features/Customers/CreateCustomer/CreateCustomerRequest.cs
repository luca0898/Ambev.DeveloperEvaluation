﻿using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer
{
    //public class CreateCustomerRequest
    //{
    //}
    public sealed record CreateCustomerRequest(CreateUserRequest UserRequest, string Name, string ExternalId);
}
