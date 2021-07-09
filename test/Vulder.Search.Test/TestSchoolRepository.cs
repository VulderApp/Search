using System;
using Mongo2Go;
using Vulder.Search.Core.ProjectAggregate.School;
using Vulder.Search.Infrastructure.Config;
using Vulder.Search.Infrastructure.Data;
using Vulder.Search.Infrastructure.Data.Repository;
using Xunit;

namespace Vulder.Search.Test
{
    public class TestSchoolRepository
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
            var school = new School(SchoolName, "https://example.com", "xyz@xyz.pl");
            school.GenerateId();
            await _repository.Create(school);
            var result = await _repository.Get(SchoolName);
            Assert.NotEmpty(result);
        }
        
        [Fact]
        public async void UpdateSchoolDocument()
        {
            var school = await _repository.Get(SchoolName);
            school[0].Name = UpdateSchoolName;
            await _repository.Update(school[0]);
            var result = await _repository.Get("ZSPnr2");
            Assert.Equal(school[0].Name, result[0].Name);
        }

        [Fact]
        public async void DeleteSchoolDocument()
        {
            var school = await _repository.Get(UpdateSchoolName);
            await _repository.Delete(school[0].Id);
            var result = await _repository.Get(UpdateSchoolName);
            Assert.Equal(school.Count - 1, result.Count);
        }
    }
}