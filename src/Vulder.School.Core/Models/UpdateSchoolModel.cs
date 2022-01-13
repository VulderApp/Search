using MediatR;

namespace Vulder.School.Core.Models;

public record UpdateSchoolModel : SchoolModel, IRequest<bool>
{
    public Guid Id { get; set; }
}