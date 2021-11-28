using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Vulder.School.Core.Models;
using Vulder.School.Core.ProjectAggregate.School.Dtos;
using Xunit;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Vulder.School.IntegrationTests.Controllers.School;

public class GetSchoolControllerTest
{
    [Fact]
    public async void GET_Responds_200_StatusCode()
    {
        var body = new AddSchoolModel
        {
            Name = "LO 2 Krakow",
            SchoolUrl = "http://example.com",
            TimetableUrl = "http://example.com/timetable"
        };
        
        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        
        var httpContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("/school/AddSchool", httpContent);
        
        using var findResponse = await client.GetAsync("school/FindSchools?input=LO");
        var findSchoolDeserialized = JsonConvert.DeserializeObject<List<FindSchoolsDto>>(await findResponse.Content.ReadAsStringAsync());

        using var getSchoolResponse =
            await client.GetAsync($"school/GetSchool?schoolId={findSchoolDeserialized![0].Id}");
        
        Assert.Equal(HttpStatusCode.OK, getSchoolResponse.StatusCode);
        Assert.NotNull(await getSchoolResponse.Content.ReadAsStringAsync());
    }
}