namespace Vulder.Search.Infrastructure.Config
{
    public interface IMongoDbConfiguration
    {
        string ConnectionString { get; set; }
    }
}