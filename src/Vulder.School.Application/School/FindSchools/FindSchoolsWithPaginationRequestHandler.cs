using MediatR;
using Vulder.School.Core.Models;
using Vulder.School.Core.ProjectAggregate.School.Dtos;
using Vulder.School.Infrastructure.Database.Interface;

namespace Vulder.School.Application.School.FindSchools;

public class FindSchoolsWithPaginationRequestHandler : IRequestHandler<FindSchoolsPaginationModel, SchoolsDto>
{
    private readonly ISchoolRepository _schoolRepository;

    public FindSchoolsWithPaginationRequestHandler(ISchoolRepository schoolRepository)
    {
        _schoolRepository = schoolRepository;
    }

    public async Task<SchoolsDto> Handle(FindSchoolsPaginationModel request, CancellationToken cancellationToken)
    {
        var pages = await _schoolRepository.GetSchoolsDocumentsCountWithPagination(request.Input!);
        var schools = await _schoolRepository.GetSchoolsByInputWithPagination(request.Input!, request.Page);

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