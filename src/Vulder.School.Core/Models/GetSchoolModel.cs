using MediatR;

namespace Vulder.School.Core.Models;

public class GetSchoolModel : IRequest<ProjectAggregate.School.School>
{
    public Guid SchoolId { get; set; }
}