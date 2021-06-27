namespace Vulder.Search.Infrastructure.Config
{
    public class MongoDbConfiguration : IMongoDbConfiguration
    {
        public string ConnectionString { get; set; }
        public string DbName { get; set; }
        public string SchoolsCollectionName { get; set; }
    }
}