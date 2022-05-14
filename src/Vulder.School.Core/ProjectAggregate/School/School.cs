using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Vulder.School.Core.ProjectAggregate.School;

public class School : IRequest<School>
{
    [BsonId]
    [BsonElement("id")]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    [BsonRequired] public string? Name { get; set; }

    [BsonRequired] public string? TimetableUrl { get; set; }

    [BsonRequired] public string? SchoolUrl { get; set; }

    public School GenerateId()
    {
        Id = Guid.NewGuid();
        return this;
    }
}