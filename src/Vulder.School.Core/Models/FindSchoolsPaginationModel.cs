using MediatR;
using Vulder.School.Core.ProjectAggregate.School.Dtos;

namespace Vulder.School.Core.Models;

public record FindSchoolsPaginationModel : IRequest<SchoolsDto>
{
    public int Page { get; set; }
    public string? Input { get; set; }
}