using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Categories.UpdateCategory
{
    /// <summary>
    /// Command for updating a category.
    /// </summary>
    public record UpdateCategoryCommand : IRequest<UpdateCategoryResult>
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string? Description { get; init; }

        public UpdateCategoryCommand() { }

        public UpdateCategoryCommand(Guid id, string name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
