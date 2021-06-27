namespace Vulder.Search.Infrastructure.Config
{
    public interface IMongoDbConfiguration
    {
        string ConnectionString { get; set; }
        string DbName { get; set; }
        string SchoolsCollectionName { get; set; }
    }
}