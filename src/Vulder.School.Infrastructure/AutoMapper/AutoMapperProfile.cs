using AutoMapper;
using Vulder.Search.Core.Models;
using Vulder.Search.Core.ProjectAggregate.School;

namespace Vulder.School.Infrastructure.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddSchoolModel, Search.Core.ProjectAggregate.School.School>();
    }
}