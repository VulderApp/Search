using System;
using System.Collections.Generic;
using System.Threading;
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

        public Task<List<School>> Find(string input)
            => Task.FromResult(_schoolCollection.Find(Builders<School>.Filter.Text(input)).Limit(10).ToList());

        public async Task<School> Get(Guid id)
        {
            var filter = Builders<School>.Filter.Eq(s => s.Id == id, true);
            return await _schoolCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task Create(School school)
        {
            await _schoolCollection.InsertOneAsync(school);
            await _schoolCollection.Indexes.CreateOneAsync(
                new CreateIndexModel<School>(Builders<School>.IndexKeys.Text(s => s.Name)));
        }

        public async Task Delete(Guid id)
            => await _schoolCollection.DeleteOneAsync(s => s.Id == id);

        public async Task Update(School school)
            => await _schoolCollection.ReplaceOneAsync(s => s.Id == school.Id, school);
    }
}