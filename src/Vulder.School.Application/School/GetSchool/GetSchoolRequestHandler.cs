using MediatR;
using Vulder.School.Core.Models;
using Vulder.School.Infrastructure.Database.Interface;

namespace Vulder.School.Application.School.GetSchool;

public class GetSchoolRequestHandler : IRequestHandler<GetSchoolModel, Core.ProjectAggregate.School.School>
{
    private readonly ISchoolRepository _schoolRepository;

    public GetSchoolRequestHandler(ISchoolRepository schoolRepository)
    {
        _schoolRepository = schoolRepository;
    }

    public async Task<Core.ProjectAggregate.School.School> Handle(GetSchoolModel request,
        CancellationToken cancellationToken)
    {
        return await _schoolRepository.GetSchoolById(request.SchoolId);
    }
}