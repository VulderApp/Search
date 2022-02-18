using MongoDB.Driver;
using Vulder.School.Infrastructure.Database.Interface;

namespace Vulder.School.Infrastructure.Database.Repository;

public class SchoolRepository : ISchoolRepository
{
    private const int DocumentLimit = 20;
    
    public SchoolRepository(MongoDbContext context)
    {
        Schools = context.Schools;
    }

    private IMongoCollection<Core.ProjectAggregate.School.School> Schools { get; }

    public async Task Create(Core.ProjectAggregate.School.School school)
    {
        await Schools.InsertOneAsync(school);
        await Schools.Indexes.CreateOneAsync(
            new CreateIndexModel<Core.ProjectAggregate.School.School>(
                Builders<Core.ProjectAggregate.School.School>.IndexKeys.Text(s => s.Name))
        );
    }

    public async Task<Core.ProjectAggregate.School.School> GetSchoolById(Guid schoolId)
    {
        return await Schools.Find(x => x.Id == schoolId).FirstOrDefaultAsync();
    }

    public async Task<long> GetSchoolDocumentsCount()
    {
        return (await Schools.CountDocumentsAsync(_ => true) / DocumentLimit) + 1;
    }

    public Task<List<Core.ProjectAggregate.School.School>> GetSchoolsWithPagination(int page)
    {
        var schools = Schools.AsQueryable()
            .Skip((page - 1) * DocumentLimit)
            .ToList();

        return Task.FromResult(schools);
    }

    public async Task<List<Core.ProjectAggregate.School.School>> GetSchoolsByInput(string input)
    {
        return await Schools.Find(Builders<Core.ProjectAggregate.School.School>.Filter.Text(input)).Limit(10)
            .ToListAsync();
    }

    public async Task<bool> Update(Core.ProjectAggregate.School.School school)
    {
        var result = await Schools.ReplaceOneAsync(x => x.Id == school.Id, school);

        return result.IsAcknowledged;
    }
}