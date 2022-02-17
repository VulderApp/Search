using MediatR;
using Vulder.School.Core.ProjectAggregate.School.Dtos;

namespace Vulder.School.Core.Models;

public record SchoolsModel : IRequest<List<SchoolsDto>>
{
    public int Page { get; set; }
}