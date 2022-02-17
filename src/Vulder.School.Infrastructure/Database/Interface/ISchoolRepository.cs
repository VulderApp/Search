namespace Vulder.School.Infrastructure.Database.Interface;

public interface ISchoolRepository
{
    Task<Core.ProjectAggregate.School.School> GetSchoolById(Guid schoolId);
    Task<List<Core.ProjectAggregate.School.School>> GetSchoolsWithPagination(int page);
    Task<List<Core.ProjectAggregate.School.School>> GetSchoolsByInput(string input);
    Task Create(Core.ProjectAggregate.School.School school);
    Task<bool> Update(Core.ProjectAggregate.School.School school);
}