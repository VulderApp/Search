using System;
using MediatR;

namespace Vulder.Search.Core.Models
{
    public class UpdateSchoolModel : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string SchoolName { get; set; }
        public string TimetableUrl { get; set; }
        public string SchoolUrl { get; set; }
        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
    }
}