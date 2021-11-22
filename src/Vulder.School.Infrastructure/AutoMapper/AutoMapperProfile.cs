using AutoMapper;
using Vulder.School.Core.Models;

namespace Vulder.School.Infrastructure.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddSchoolModel, Core.ProjectAggregate.School.School>();
    }
}