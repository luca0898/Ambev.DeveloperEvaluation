namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.UpdateBranch
{
    public class UpdateBranchResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}
