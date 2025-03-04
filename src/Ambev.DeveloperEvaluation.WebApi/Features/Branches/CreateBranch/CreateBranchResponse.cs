namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch
{
    public class CreateBranchResponse
    {
        public Guid Id { get; set; }
        public string Location { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
    }
}
