using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Vulder.School.Core.Models;
using Vulder.School.IntegrationTests.Fixtures;
using Newtonsoft.Json;
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
        var httpContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("/school/AddSchool", httpContent);
        var schoolModel = JsonConvert.DeserializeObject<AddSchoolModel>(await response.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(body.Name, schoolModel?.Name);
        Assert.Equal(body.SchoolUrl, schoolModel?.SchoolUrl);
        Assert.Equal(body.TimetableUrl, schoolModel?.TimetableUrl);
    }
}