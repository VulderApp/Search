namespace Vulder.School.Infrastructure.Database.Interface;

public interface ISchoolRepository
{
    Task<List<Core.ProjectAggregate.School.School>> GetSchoolsByInput(string input);
    Task<Core.ProjectAggregate.School.School> GetSchoolById(Guid schoolId);
    Task Create(Core.ProjectAggregate.School.School school);
}