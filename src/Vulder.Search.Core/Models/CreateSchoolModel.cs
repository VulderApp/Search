using MediatR;

namespace Vulder.Search.Core.Models
{
    public class CreateSchoolModel : IRequest
    {
        public string Name { get; set; }
        public string TimetableUrl { get; set; }
        public string SchoolUrl { get; set; }
        public string RequesterId { get; set; }
        public string RequesterEmail { get; set; }
    }
}