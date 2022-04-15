using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Vulder.School.Core.Models;
using Vulder.School.IntegrationTests.Fixtures;
using Newtonsoft.Json;
using Xunit;
using Vulder.School.Core.ProjectAggregate.School.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit.Priority;

namespace Vulder.School.IntegrationTests.Controllers;

[Collection("Schools collection")]
[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class SchoolControllersTest
{
    private readonly SchoolFixture _schoolFixture;

    public SchoolControllersTest(SchoolFixture schoolFixture)
    {
        _schoolFixture = schoolFixture;
    }

    [Fact]
    [Priority(0)]
    public async Task AddSchool_POST_Responds_200_StatusCode()
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
        using var response = await client.PostAsync("/school/add", httpContent);
        var schoolModel = JsonConvert.DeserializeObject<Core.ProjectAggregate.School.School>(await response.Content.ReadAsStringAsync());
        
        _schoolFixture.SchoolModel = schoolModel!;

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(body.Name, schoolModel?.Name);
        Assert.Equal(body.SchoolUrl, schoolModel?.SchoolUrl);
        Assert.Equal(body.TimetableUrl, schoolModel?.TimetableUrl);
    }

    [Fact]
    [Priority(1)]
    public async void FindSchools_GET_Responds_1_Model()
    {
        await using var application = new WebServerFactory();
        using var client = application.CreateClient();

        using var findResponse = await client.GetAsync("/school/find?input=ZSP");
        var deserializedResponse =
            JsonConvert.DeserializeObject<List<SchoolItemDto>>(await findResponse.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, findResponse.StatusCode);
        Assert.True(Guid.TryParse(deserializedResponse?.Select(x => x.Id).FirstOrDefault().ToString(), out _));
        Assert.NotNull(deserializedResponse!.First(x => x.Name == _schoolFixture.SchoolModel?.Name));
    }

    [Fact]
    [Priority(2)]
    public async void FindSchoolsWithPagination_GET_Responds_200_StatusCode()
    {
        await using var application = new WebServerFactory();
        using var client = application.CreateClient();

        using var findResponse = await client.GetAsync("/school/findWithPagination?input=ZSP&page=1");
        var deserializedResponse =
            JsonConvert.DeserializeObject<SchoolsDto>(await findResponse.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, findResponse.StatusCode);
        Assert.Equal(1, deserializedResponse?.Pages);
        Assert.True(Guid.TryParse(deserializedResponse?.Schools?.Select(x => x.Id).FirstOrDefault().ToString(), out _));
        Assert.NotNull(deserializedResponse?.Schools?.Where(x => x.Name == _schoolFixture.SchoolModel?.Name).First());
    }

    [Fact]
    [Priority(3)]
    public async void GetSchool_GET_Responds_200_StatusCode()
    {
        await using var application = new WebServerFactory();
        using var client = application.CreateClient();

        using var getSchoolResponse =
            await client.GetAsync($"school?schoolId={_schoolFixture.SchoolModel?.Id}");
        var schoolModel = JsonConvert.DeserializeObject<Core.ProjectAggregate.School.School>(await getSchoolResponse.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, getSchoolResponse.StatusCode);
        Assert.True(Guid.TryParse(schoolModel?.Id.ToString(), out _));
        Assert.Equal(_schoolFixture.SchoolModel?.Name, schoolModel?.Name);
        Assert.Equal(_schoolFixture.SchoolModel?.SchoolUrl, schoolModel?.SchoolUrl);
        Assert.Equal(_schoolFixture.SchoolModel?.TimetableUrl, schoolModel?.TimetableUrl);
    }

    [Fact]
    [Priority(4)]
    public async void Schools_GET_Responds_200_StatusCode()
    {
        await using var application = new WebServerFactory();
        using var client = application.CreateClient();

        using var response = await client.GetAsync("school/schools?page=1");
        var schoolModel = JsonConvert.DeserializeObject<SchoolsDto>(await response.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(1, schoolModel?.Pages);
        Assert.NotNull(schoolModel?.Schools?[0].Name);
        Assert.True(Guid.TryParse(schoolModel?.Schools?[0].Id.ToString(), out _));
        Assert.NotEqual(Guid.Empty, schoolModel?.Schools?[0].Id);
    }

    [Fact]
    [Priority(5)]
    public async Task UpdateSchool_POST_Responds_200_StatusCode()
    {
        var updateSchoolModel = new UpdateSchoolModel
        {
            Id = _schoolFixture.SchoolModel!.Id,
            Name = "ZSP 2 in Warsaw",
            SchoolUrl = "http://example.com",
            TimetableUrl = "http://example.com/timetable"
        };

        await using var application = new WebServerFactory();
        using var client = application.CreateClient();

        var httpContent = new StringContent(JsonConvert.SerializeObject(updateSchoolModel), Encoding.UTF8,
            "application/json");
        using var updateResponse = await client.PutAsync("/school/update", httpContent);
        var resultModel = JsonConvert.DeserializeObject<ResultDto>(await updateResponse.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);
        Assert.True(resultModel?.Result);
    }

    [Fact]
    [Priority(6)]
    public async Task DeleteSchool_POST_Responds_200_StatusCode()
    {
        await using var application = new WebServerFactory();
        using var client = application.CreateClient();

        using var deleteResponse = await client.DeleteAsync($"/school/delete?schoolId={_schoolFixture.SchoolModel?.Id}");
        var deleteModel = JsonConvert.DeserializeObject<ResultDto>(await deleteResponse.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);
        Assert.True(deleteModel?.Result);
    }
}