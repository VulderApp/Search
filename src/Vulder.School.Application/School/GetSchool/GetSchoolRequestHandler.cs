using MediatR;
using Vulder.School.Core.Models;
using Vulder.School.Core.ProjectAggregate.School;
using Vulder.School.Infrastructure.Database.Interface;
using Vulder.School.Infrastructure.Redis.Interfaces;

namespace Vulder.School.Application.School.GetSchool;

public class GetSchoolRequestHandler : IRequestHandler<GetSchoolModel, Core.ProjectAggregate.School.School>
{
    private readonly ISchoolRepository _schoolRepository;
    private readonly ISchoolCacheRepository _schoolCacheRepository;

    public GetSchoolRequestHandler(ISchoolRepository schoolRepository, ISchoolCacheRepository schoolCacheRepository)
    {
        _schoolRepository = schoolRepository;
        _schoolCacheRepository = schoolCacheRepository;
    }

    public async Task<Core.ProjectAggregate.School.School> Handle(GetSchoolModel request,
        CancellationToken cancellationToken)
    {
        var schoolFromCache = await _schoolCacheRepository.GetSchoolById(request.SchoolId);
        if (schoolFromCache?.School != null && schoolFromCache.ExpiredAt < DateTimeOffset.Now)
            return schoolFromCache.School;
        
        var school = await _schoolRepository.GetSchoolById(request.SchoolId);
        var schoolCache = new SchoolCache
        {
            School = school
        };
        
        await _schoolCacheRepository.Create(school.Id, schoolCache);
        return school;
    }
}