namespace Vulder.School.Core.ProjectAggregate.School.Dtos;

public record SchoolItemDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}