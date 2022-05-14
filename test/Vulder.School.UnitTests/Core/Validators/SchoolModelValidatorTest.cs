using FluentValidation.TestHelper;
using Vulder.School.Core.Models;
using Vulder.School.Core.Validators;
using Xunit;

namespace Vulder.Search.UnitTests.Core.Validators;

public class SchoolModelValidatorTest
{
    [Fact]
    public void ValidateSchoolModel_Correct()
    {
        var schoolModel = new SchoolModel
        {
            Name = "ZSP 2 w Warszawie",
            SchoolUrl = "http://example.com",
            TimetableUrl = "http://example.com/timetable"
        };

        var result = new SchoolModelValidator().TestValidate(schoolModel).IsValid;

        Assert.True(result);
    }

    [Fact]
    public void ValidateSchoolModel_NotValid()
    {
        var schoolModel = new SchoolModel
        {
            Name = "",
            SchoolUrl = "http://example.com",
            TimetableUrl = "http://example.com"
        };

        var result = new SchoolModelValidator().TestValidate(schoolModel).IsValid;

        Assert.False(result);
    }
}