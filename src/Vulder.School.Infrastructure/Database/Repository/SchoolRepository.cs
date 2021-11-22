using MongoDB.Driver;
using Vulder.School.Infrastructure.Database.Interface;

namespace Vulder.School.Infrastructure.Database.Repository;

public class SchoolRepository : ISchoolRepository
{
    public SchoolRepository(MongoDbContext context)
    {
        Schools = context.Schools;
    }

    private IMongoCollection<Search.Core.ProjectAggregate.School.School> Schools { get; }

    public async Task Create(Search.Core.ProjectAggregate.School.School school)
    {
        await Schools.InsertOneAsync(school);
        await Schools.Indexes.CreateOneAsync(
            new CreateIndexModel<Search.Core.ProjectAggregate.School.School>(
                Builders<Search.Core.ProjectAggregate.School.School>.IndexKeys.Text(s => s.Name))
        );
    }

    public async Task<List<Search.Core.ProjectAggregate.School.School>> GetSchoolsByInput(string input)
    {
        return await Schools.Find(Builders<Search.Core.ProjectAggregate.School.School>.Filter.Text(input)).Limit(10)
            .ToListAsync();
    }
}