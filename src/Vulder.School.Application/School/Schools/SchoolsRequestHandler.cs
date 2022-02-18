using MediatR;
using Vulder.School.Core.Models;
using Vulder.School.Core.ProjectAggregate.School.Dtos;
using Vulder.School.Infrastructure.Database.Interface;

namespace Vulder.School.Application.School.Schools;

public class SchoolsRequestHandler : IRequestHandler<SchoolsModel, SchoolsDto>
{
    private readonly ISchoolRepository _schoolRepository;

    public SchoolsRequestHandler(ISchoolRepository schoolRepository)
    {
        _schoolRepository = schoolRepository;
    }

    public async Task<SchoolsDto> Handle(SchoolsModel request, CancellationToken cancellationToken)
    {
        var pages = await _schoolRepository.GetSchoolDocumentsCount();
        var schools = await _schoolRepository.GetSchoolsWithPagination(request.Page);

        var schoolItemsDto = schools.Select(x => new SchoolItemDto
        {
            Id = x.Id,
            Name = x.Name
        }).ToList();

        return new SchoolsDto
        {
            Schools = schoolItemsDto,
            Pages = pages
        };
    }
}