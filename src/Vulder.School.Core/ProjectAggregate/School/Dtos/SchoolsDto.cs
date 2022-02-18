namespace Vulder.School.Core.ProjectAggregate.School.Dtos;

public record SchoolsDto
{
    public List<SchoolItemDto>? Schools { get; set; }
    public long Pages { get; set; }
}