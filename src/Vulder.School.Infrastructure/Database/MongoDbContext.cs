using MongoDB.Driver;

namespace Vulder.School.Infrastructure.Database;

public class MongoDbContext
{
    public MongoDbContext()
    {
        var client = new MongoClient();
        var database = client.GetDatabase("Vulder");
        Schools = database.GetCollection<Core.ProjectAggregate.School.School>("Schools");
    }

    public IMongoCollection<Core.ProjectAggregate.School.School> Schools { get; }
}