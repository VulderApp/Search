using MediatR;

namespace Vulder.School.Core.Models;

public class FindSchoolModel : IRequest<List<Core.ProjectAggregate.School.School>>
{
    public string? Input { get; set; }
}