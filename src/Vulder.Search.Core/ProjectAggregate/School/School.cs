using System;
using MongoDB.Bson.Serialization.Attributes;
using Vulder.SharedKernel;

namespace Vulder.Search.Core.ProjectAggregate.School
{
    public class School : BaseEntity
    {
        [BsonRequired]
        public string Name { get; set; }
        
        [BsonRequired]
        public string TimetableUrl { get; set; }
        
        [BsonRequired]
        public string SchoolUrl { get; set; }
        
        [BsonRequired]
        public Guid GuardianId { get; set; }
        
        [BsonRequired]
        public string GuardianEmail { get; set; }

        public School GenerateId()
        {
            Id = Guid.NewGuid();
            return this;
        }
    }
}