using System;
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
            var client = new MongoClient(Environment.GetEnvironmentVariable("MongoServer") ?? configuration.ConnectionString);
            var db = client.GetDatabase("Vulder");
            SchoolsCollection = db.GetCollection<School>("Schools");
        }
    }
}