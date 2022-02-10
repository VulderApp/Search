namespace Vulder.School.Core;

public static class Constants
{
    public static readonly string MongoDbConnectionString =
        Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING") ?? string.Empty;
}