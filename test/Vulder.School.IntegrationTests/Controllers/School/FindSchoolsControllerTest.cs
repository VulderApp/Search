using System;
using System.Collections.Generic;
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

public class FindSchoolsControllerTest
{
    [Fact]
    public async void GET_Responds_1_Model()
    {
        var body = new AddSchoolModel
        {
            Name = "SP 2 w Warszawie",
            SchoolUrl = "http://example.com",
            TimetableUrl = "http://example.com/timetable"
        };

        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        await client.PostAsync("/school/AddSchool", httpContent);
        using var findResponse = await client.GetAsync("school/FindSchools?input=SP");

        var deserializedResponse =
            JsonConvert.DeserializeObject<List<SchoolItemDto>>(await findResponse.Content.ReadAsStringAsync() ??
                                                               throw new InvalidOperationException());

        Assert.Equal(HttpStatusCode.OK, findResponse.StatusCode);
        Assert.Single(deserializedResponse!.Where(x => x.Name == body.Name));
    }
}