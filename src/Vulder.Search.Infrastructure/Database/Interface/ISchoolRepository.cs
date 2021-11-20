using Vulder.Search.Core.ProjectAggregate.School;

namespace Vulder.Search.Infrastructure.Database.Interface;

public interface ISchoolRepository
{
    Task<List<School>> GetSchoolsByInput(string input);
    Task Create(School school);
}