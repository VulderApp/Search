using System;
using Vulder.Search.Core.ProjectAggregate.School;
using Xunit;

namespace Vulder.Search.Test
{
    public class TestSchoolEntity
    {
        private const int GuidLenght = 36;
        private readonly School _school;

        public TestSchoolEntity()
        {
            _school = new School("ZSPnr1", "http://example.com", "xyz@example.com");
        }
        
        [Fact]
        public void GenerateId()
        {
            _school.GenerateId();
            Assert.IsType<Guid>(_school.Id);
            Assert.Equal(GuidLenght, _school.Id.ToString().Length);
        }
    }
}