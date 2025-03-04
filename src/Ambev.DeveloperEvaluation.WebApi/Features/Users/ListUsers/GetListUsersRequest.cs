﻿namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers
{
    public class GetListUsersRequest
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? OrderBy { get; set; }
    }

}
