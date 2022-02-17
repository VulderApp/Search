using MediatR;
using Vulder.School.Core.Models;
using Vulder.School.Core.ProjectAggregate.School.Dtos;
using Vulder.School.Infrastructure.Database.Interface;

namespace Vulder.School.Application.School.Schools;

public class SchoolsRequestHandler : IRequestHandler<SchoolsModel, List<SchoolsDto>>
{
    private readonly ISchoolRepository _schoolRepository;
    
    public SchoolsRequestHandler(ISchoolRepository schoolRepository)
    {
        _schoolRepository = schoolRepository;
    }
    
    public async Task<List<SchoolsDto>> Handle(SchoolsModel request, CancellationToken cancellationToken)
    {
        var schools = await _schoolRepository.GetSchoolsWithPagination(request.Page);

        return schools.Select(x => new SchoolsDto
        {
            Id = x.Id,
            Name = x.Name
        }).ToList();
    }
}