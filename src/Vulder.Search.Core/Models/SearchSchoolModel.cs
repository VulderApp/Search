using System.Collections.Generic;
using MediatR;
using Vulder.Search.Core.ProjectAggregate.School;

namespace Vulder.Search.Core.Models
{
    public class SearchSchoolModel : IRequest<List<School>>

    {
    public string Input { get; set; }
    }
}