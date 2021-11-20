using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using Vulder.SharedKernel;

namespace Vulder.Search.Core.ProjectAggregate.School;

public class School : BaseEntity, IRequest<bool>
{
    [BsonRequired]
    public string Name { get; set; }
        
    [BsonRequired]
    public string TimetableUrl { get; set; }
        
    [BsonRequired]
    public string SchoolUrl { get; set; }

    public School GenerateId()
    {
        Id = Guid.NewGuid();
        return this;
    }
}