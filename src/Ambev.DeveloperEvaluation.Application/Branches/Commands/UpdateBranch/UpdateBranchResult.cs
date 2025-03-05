namespace Ambev.DeveloperEvaluation.Application.Branches.Commands.UpdateBranch;

public class UpdateBranchResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
}
