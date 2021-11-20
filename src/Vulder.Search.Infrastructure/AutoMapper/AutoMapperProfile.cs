using AutoMapper;
using Vulder.Search.Core.Models;
using Vulder.Search.Core.ProjectAggregate.School;

namespace Vulder.Search.Infrastructure.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddSchoolModel, School>();
    }
}