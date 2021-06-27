using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Vulder.Search.Core.ProjectAggregate.School;

namespace Vulder.Search.Infrastructure.Data.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly IMongoCollection<School> _schoolCollection;
        
        public SchoolRepository(MongoDbContext context)
        {
            _schoolCollection = context.SchoolsCollection;
        }

        public Task<List<School>> Get(string input)
            => Task.FromResult(_schoolCollection.Find(s => s.Name == input).Limit(10).ToList());

        public async Task Create(School school)
            => await _schoolCollection.InsertOneAsync(school);

        public async Task Delete(Guid id)
            => await _schoolCollection.DeleteOneAsync(s => s.Id == id);

        public async Task Update(School school)
            => await _schoolCollection.ReplaceOneAsync(s => s.Id == school.Id, school);
    }
}