namespace Vulder.Search.Infrastructure.Config
{
    public class MongoDbConfiguration : IMongoDbConfiguration
    {
        public string ConnectionString { get; set; }
    }
}