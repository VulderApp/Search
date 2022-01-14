using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vulder.School.Core.Models;
using Vulder.School.Core.ProjectAggregate.School.Dtos;
using Vulder.School.IntegrationTests.Fixtures;
using Xunit;

namespace Vulder.School.IntegrationTests.Controllers.School;

public class UpdateSchoolControllerTest
{
    [Fact]
    public async Task POST_Responds_200_StatusCode()
    {
        var schoolModel = new AddSchoolModel
        {
            Name = "ZSP 2 w Waw",
            SchoolUrl = "http://example.com",
            TimetableUrl = "http://example.com/timetable"
        };

        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonSerializer.Serialize(schoolModel), Encoding.UTF8, "application/json");
        using var addResponse = await client.PostAsync("/school/AddSchool", httpContent);
        var schoolId = JsonConvert.DeserializeObject<Core.ProjectAggregate.School.School>(await addResponse.Content.ReadAsStringAsync())!.Id;

        var updateSchoolModel = new UpdateSchoolModel
        {
            Id = schoolId,
            Name = "ZSP 2 in Warsaw",
            SchoolUrl = "http://example.com",
            TimetableUrl = "http://example.com/timetable"
        };
        
        httpContent = new StringContent(JsonConvert.SerializeObject(updateSchoolModel), Encoding.UTF8, "application/json");
        using var updateResponse = await client.PutAsync("/school/UpdateSchool", httpContent);
        
        Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);
        Assert.True(JsonConvert.DeserializeObject<UpdateDto>(await updateResponse.Content.ReadAsStringAsync())!.Result);
    }
}