using System.Net;
using Vulder.School.IntegrationTests.Fixtures;
using Xunit;

namespace Vulder.School.IntegrationTests.Controllers.School;

public class SchoolsControllerTest
{
    [Fact]
    public async void GET_Responds_200_StatusCode()
    {
        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        using var response = await client.GetAsync("school/Schools?page=1");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}