using Vulder.School.IntegrationTests.Fixtures;
using Xunit;

namespace Vulder.School.IntegrationTests.Controllers;

[CollectionDefinition("Schools collection")]
public class SchoolCollection : ICollectionFixture<SchoolFixture>
{
}