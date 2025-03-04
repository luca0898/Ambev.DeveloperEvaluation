namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers
{
    public class GetListUsersRequest
    {
        /// <summary>
        /// Page number for pagination (default: 1)
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Number of items per page (default: 10)
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Ordering of results (e.g., "username asc, email desc")
        /// </summary>
        public string? OrderBy { get; set; }
    }

}
