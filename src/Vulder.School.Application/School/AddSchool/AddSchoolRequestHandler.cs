using MediatR;
using Vulder.School.Infrastructure.Database.Interface;

namespace Vulder.School.Application.School.AddSchool;

public class AddSchoolRequestHandler : IRequestHandler<Core.ProjectAggregate.School.School, Core.ProjectAggregate.School.School>
{
    private readonly ISchoolRepository _schoolRepository;

    public AddSchoolRequestHandler(ISchoolRepository schoolRepository)
    {
        _schoolRepository = schoolRepository;
    }

    public async Task<Core.ProjectAggregate.School.School> Handle(Core.ProjectAggregate.School.School request,
        CancellationToken cancellationToken)
    {
        await _schoolRepository.Create(request.GenerateId());

        return request;
    }
}