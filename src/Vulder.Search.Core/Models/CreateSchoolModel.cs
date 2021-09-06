using MediatR;

namespace Vulder.Search.Core.Models
{
    public class CreateSchoolModel : IRequest
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string RequesterEmail { get; set; }
    }
}