namespace Vulder.School.Core.ProjectAggregate.School;

public class SchoolCache
{
    public DateTimeOffset ExpiredAt { get; set; }
    public School? School { get; set; }

    public SchoolCache()
    {
        ExpiredAt = DateTimeOffset.Now.AddHours(1);
    }
}