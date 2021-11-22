using Vulder.Search.Core.ProjectAggregate.School;

namespace Vulder.School.Infrastructure.Database.Interface;

public interface ISchoolRepository
{
    Task<List<Search.Core.ProjectAggregate.School.School>> GetSchoolsByInput(string input);
    Task Create(Search.Core.ProjectAggregate.School.School school);
}