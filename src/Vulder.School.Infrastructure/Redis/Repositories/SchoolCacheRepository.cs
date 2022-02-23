using Newtonsoft.Json;
using StackExchange.Redis;
using Vulder.School.Core.ProjectAggregate.School;
using Vulder.School.Infrastructure.Redis.Interfaces;

namespace Vulder.School.Infrastructure.Redis.Repositories;

public class SchoolCacheRepository : ISchoolCacheRepository
{
    public SchoolCacheRepository(RedisContext context)
    {
        Schools = context.Schools;
    }

    private IDatabase Schools { get; }

    public async Task Create(Guid schoolId, SchoolCache schoolCache)
    {
        await Schools.StringSetAsync(schoolId.ToString(), JsonConvert.SerializeObject(schoolCache));
    }

    public async Task<SchoolCache?> GetSchoolById(Guid schoolId)
    {
        try
        {
            var school = await Schools.StringGetAsync(schoolId.ToString());

            return school.ToString() == null
                ? null
                : JsonConvert.DeserializeObject<SchoolCache>(school);
        }
        catch (JsonException)
        {
            return null;
        }
    }
}