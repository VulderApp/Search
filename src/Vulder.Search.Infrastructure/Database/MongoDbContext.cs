using MongoDB.Driver;
using Vulder.Search.Core.ProjectAggregate.School;

namespace Vulder.Search.Infrastructure.Database;

public class MongoDbContext
{
    public IMongoCollection<School> Schools { get; }

    public MongoDbContext()
    {
        var client = new MongoClient();
        var database = client.GetDatabase("Vulder");
        Schools = database.GetCollection<School>("Schools");
    }
}