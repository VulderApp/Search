using MongoDB.Driver;

namespace Vulder.School.Infrastructure.Database;

public class MongoDbContext
{
    public IMongoCollection<School.Core.ProjectAggregate.School.School> Schools { get; }

    public MongoDbContext()
    {
        var client = new MongoClient();
        var database = client.GetDatabase("Vulder");
        Schools = database.GetCollection<Search.Core.ProjectAggregate.School.School>("Schools");
    }

    public IMongoCollection<School.Core.ProjectAggregate.School.School> Schools { get; }
}