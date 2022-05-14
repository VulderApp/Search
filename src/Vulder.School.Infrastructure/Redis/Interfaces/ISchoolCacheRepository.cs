using Vulder.School.Core.ProjectAggregate.School;

namespace Vulder.School.Infrastructure.Redis.Interfaces;

public interface ISchoolCacheRepository
{
    Task Create(Guid schoolId, SchoolCache schoolCache);
    Task<SchoolCache?> GetSchoolById(Guid schoolId);
}