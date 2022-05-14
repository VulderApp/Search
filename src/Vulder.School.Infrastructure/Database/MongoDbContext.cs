using MongoDB.Driver;
using Vulder.School.Core;

namespace Vulder.School.Infrastructure.Database;

public class MongoDbContext
{
    public MongoDbContext()
    {
        var client = new MongoClient(Constants.MongoDbConnectionString);
        var database = client.GetDatabase("Vulder");
        Schools = database.GetCollection<Core.ProjectAggregate.School.School>("Schools");
    }

    public IMongoCollection<Core.ProjectAggregate.School.School> Schools { get; }
}