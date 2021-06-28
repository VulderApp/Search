using MongoDB.Driver;
using Vulder.Search.Core.ProjectAggregate.School;
using Vulder.Search.Infrastructure.Config;

namespace Vulder.Search.Infrastructure.Data
{
    public class MongoDbContext
    {
        public IMongoCollection<School> SchoolsCollection { get; }

        public MongoDbContext(IMongoDbConfiguration configuration)
        {
            var client = new MongoClient(configuration.ConnectionString);
            var db = client.GetDatabase(configuration.DbName);
            SchoolsCollection = db.GetCollection<School>(configuration.SchoolsCollectionName);
        }
    }
}