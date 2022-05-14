using MediatR;
using Vulder.School.Core.ProjectAggregate.School.Dtos;

namespace Vulder.School.Core.Models;

public record DeleteSchoolModel : IRequest<ResultDto>
{
    public Guid Id { get; set; }
}