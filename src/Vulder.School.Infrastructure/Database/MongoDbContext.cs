using MongoDB.Driver;
using Vulder.Search.Core.ProjectAggregate.School;

namespace Vulder.School.Infrastructure.Database;

public class MongoDbContext
{
    public IMongoCollection<Search.Core.ProjectAggregate.School.School> Schools { get; }

    public MongoDbContext()
    {
        var client = new MongoClient();
        var database = client.GetDatabase("Vulder");
        Schools = database.GetCollection<Search.Core.ProjectAggregate.School.School>("Schools");
    }
}