namespace Vulder.School.Infrastructure.Database.Interface;

public interface ISchoolRepository
{
    Task<List<Core.ProjectAggregate.School.School>> GetSchoolsByInput(string input);
    Task Create(Core.ProjectAggregate.School.School school);
}