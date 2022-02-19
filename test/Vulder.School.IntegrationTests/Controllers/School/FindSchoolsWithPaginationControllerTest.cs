using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Vulder.School.Core.Models;
using Vulder.School.Core.ProjectAggregate.School.Dtos;
using Vulder.School.IntegrationTests.Fixtures;
using Xunit;

namespace Vulder.School.IntegrationTests.Controllers.School;

public class FindSchoolsWithPaginationControllerTest
{
    [Fact]
    public async void GET_Responds_200_StatusCode()
    {
        var body = new AddSchoolModel
        {
            Name = "SP 3 w Warszawie",
            SchoolUrl = "http://example.com",
            TimetableUrl = "http://example.com/timetable"
        };

        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        await client.PostAsync("/school/AddSchool", httpContent);

        using var findResponse = await client.GetAsync("school/FindSchoolsWithPagination?input=SP&page=1");
        var serializedResponse =
            JsonConvert.DeserializeObject<SchoolsDto>(await findResponse.Content.ReadAsStringAsync()) ??
            throw new InvalidOperationException();

        Assert.Equal(HttpStatusCode.OK, findResponse.StatusCode);
        Assert.Single(serializedResponse.Schools!.Where(x => x.Name == body.Name));
    }
}