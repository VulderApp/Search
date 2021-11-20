using MediatR;

namespace Vulder.Search.Core.Models;

public record AddSchoolModel
{
    public string Name { get; set; }
    public string TimetableUrl { get; set; }
    public string SchoolUrl { get; set; }
}