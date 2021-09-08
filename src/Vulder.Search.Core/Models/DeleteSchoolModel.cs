using System;
using MediatR;

namespace Vulder.Search.Core.Models
{
    public class DeleteSchoolModel : IRequest<bool>
    {
        public Guid SchoolId { get; set; }
    }
}