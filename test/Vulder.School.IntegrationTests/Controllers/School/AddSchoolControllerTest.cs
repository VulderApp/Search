using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Vulder.Search.Core.Models;
using Xunit;

namespace Vulder.School.IntegrationTests.Controllers.School;

public class AddSchoolControllerTest
{
    [Fact]
    public async Task POST_Responds_200_StatusCode()
    {
        var body = new AddSchoolModel
        {
            Name = "ZSP 2 w Warszawie",
            SchoolUrl = "http://example.com",
            TimetableUrl = "http://example.com/timetable"
        };
        
        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("/school/AddSchool", httpContent);
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}