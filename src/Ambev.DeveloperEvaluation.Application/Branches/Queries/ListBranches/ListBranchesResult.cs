namespace Ambev.DeveloperEvaluation.Application.Branches.Queries.ListBranches;

public class ListBranchesResult
{
    public int TotalCount { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public List<BranchDto> Branches { get; set; } = [];
}
public class BranchDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
}
