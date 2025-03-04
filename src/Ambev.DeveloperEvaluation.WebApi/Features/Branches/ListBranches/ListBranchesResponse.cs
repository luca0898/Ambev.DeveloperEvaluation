namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.ListBranches
{
    public class ListBranchesResponse
    {
        public List<BranchResponse> Categories { get; set; } = [];
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }

    public class BranchResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}
