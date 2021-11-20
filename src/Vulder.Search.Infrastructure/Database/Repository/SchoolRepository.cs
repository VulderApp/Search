using MongoDB.Driver;
using Vulder.Search.Core.ProjectAggregate.School;
using Vulder.Search.Infrastructure.Database.Interface;

namespace Vulder.Search.Infrastructure.Database.Repository;

public class SchoolRepository : ISchoolRepository
{
    private IMongoCollection<School> Schools { get; }

    public SchoolRepository(MongoDbContext context)
    {
        Schools = context.Schools;
    }
    
    public async Task Create(School school)
    {
        await Schools.InsertOneAsync(school);
        await Schools.Indexes.CreateOneAsync(
            new CreateIndexModel<School>(Builders<School>.IndexKeys.Text(s => s.Name))
            );
    }

    public async Task<List<School>> GetSchoolsByInput(string input)
        => await Schools.Find(Builders<School>.Filter.Text(input)).Limit(10).ToListAsync();
}