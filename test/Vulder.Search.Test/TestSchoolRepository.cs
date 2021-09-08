using System;
using Mongo2Go;
using Vulder.Search.Core.ProjectAggregate.School;
using Vulder.Search.Infrastructure.Config;
using Vulder.Search.Infrastructure.Data;
using Vulder.Search.Infrastructure.Data.Repository;
using Xunit;

namespace Vulder.Search.Test
{
    public class TestSchoolRepository : IDisposable
    {
        private const string SchoolName = "ZSPnr1";
        private const string UpdateSchoolName = "ZSPnr2";
        private readonly MongoDbRunner _runner;
        private readonly SchoolRepository _repository;
        
        public TestSchoolRepository()
        {
            _runner = MongoDbRunner.StartForDebugging();
            var config = new MongoDbConfiguration
            {
                ConnectionString = _runner.ConnectionString
            };
            _repository = new SchoolRepository(new MongoDbContext(config));
        }

        [Fact]
        public async void CreateSchoolDocument()
        {
            var school = new School
            {
                Name = SchoolName,
                TimetableUrl = "http://example.com/timetable",
                SchoolUrl = "http://example.com",
                GuardianId = Guid.NewGuid(),
                GuardianEmail = "xyz@xyz.pl"
            };
            
            school.GenerateId();
            await _repository.Create(school);
            var result = await _repository.Find(SchoolName);
            
            Assert.NotEmpty(result);
        }
        
        [Fact]
        public async void UpdateSchoolDocument()
        {
            var schoolEnt = new School
            {
                Name = SchoolName,
                TimetableUrl = "http://example.com/timetable",
                SchoolUrl = "http://example.com",
                GuardianId = Guid.NewGuid(),
                GuardianEmail = "xyz@xyz.pl"
            };
            schoolEnt.GenerateId();
            await _repository.Create(schoolEnt);

            schoolEnt.Name = UpdateSchoolName;
            await _repository.Update(schoolEnt);
            var result = await _repository.Find("ZSPnr2");
            
            Assert.Equal(schoolEnt.Name, result[0].Name);
        }

        [Fact]
        public async void DeleteSchoolDocument()
        {
            var schoolEnt = new School
            { 
                Name = SchoolName,
                TimetableUrl = "http://example.com/timetable",
                SchoolUrl = "http://example.com",
                GuardianId = Guid.NewGuid(),
                GuardianEmail = "xyz@xyz.pl"
            };
            schoolEnt.GenerateId();
            await _repository.Create(schoolEnt);
            await _repository.Delete(schoolEnt.Id);
        }

        public void Dispose()
        {
            _runner.Dispose();
        }
    }
}