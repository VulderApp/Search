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
        public string Url { get; set; }
        
        [BsonRequired]
        public string GuardianEmail { get; set; }
        
        public void GenerateId()
            => Id = Guid.NewGuid();
    }
}