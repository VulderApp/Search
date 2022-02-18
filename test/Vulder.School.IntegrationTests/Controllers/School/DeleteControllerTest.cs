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

public class DeleteControllerTest
{
    [Fact]
    public async Task POST_Responds_200_StatusCode()
    {
        var schoolModel = new AddSchoolModel
        {
            Name = "ZSP 404 w Warszawie",
            SchoolUrl = "http://example.com",
            TimetableUrl = "http://example.com/timetable"
        };

        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        
        var httpContent = new StringContent(JsonConvert.SerializeObject(schoolModel), Encoding.UTF8, "application/json");
        using var addResponse = await client.PostAsync("/school/AddSchool", httpContent);
        var schoolId = JsonConvert.DeserializeObject<Core.ProjectAggregate.School.School>(await addResponse.Content.ReadAsStringAsync())!.Id;

        var updateSchoolModel = new DeleteSchoolModel
        {
            Id = schoolId,
        };
        
        httpContent = new StringContent(JsonConvert.SerializeObject(updateSchoolModel), Encoding.UTF8, "application/json");
        using var deleteResponse = await client.PutAsync("/school/UpdateSchool", httpContent);
        
        Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);
        Assert.True(JsonConvert.DeserializeObject<ResultDto>(await deleteResponse.Content.ReadAsStringAsync())!.Result);
    }
}