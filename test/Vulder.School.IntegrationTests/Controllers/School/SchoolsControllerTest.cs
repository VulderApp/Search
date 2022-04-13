using System;
using System.Net;
using Newtonsoft.Json;
using Vulder.School.Core.ProjectAggregate.School.Dtos;
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
        var schoolModel = JsonConvert.DeserializeObject<SchoolsDto>(await response.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(1, schoolModel?.Pages);
        Assert.NotNull(schoolModel?.Schools?[0].Name);
        Assert.True(Guid.TryParse(schoolModel?.Schools?[0].Id.ToString(), out _));
        Assert.NotEqual(Guid.Empty, schoolModel?.Schools?[0].Id);
    }
}