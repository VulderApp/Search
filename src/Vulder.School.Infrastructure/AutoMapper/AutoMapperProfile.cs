using AutoMapper;
using Vulder.Search.Core.Models;

namespace Vulder.School.Infrastructure.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddSchoolModel, Search.Core.ProjectAggregate.School.School>();
    }
}