using MediatR;
using Vulder.School.Core.Models;
using Vulder.School.Core.ProjectAggregate.School.Dtos;
using Vulder.School.Infrastructure.Database.Interface;

namespace Vulder.School.Application.School.UpdateSchool;

public class UpdateSchoolRequestHandler : IRequestHandler<UpdateSchoolModel, ResultDto>
{
    private readonly ISchoolRepository _schoolRepository;
    
    public UpdateSchoolRequestHandler(ISchoolRepository schoolRepository)
    {
        _schoolRepository = schoolRepository;
    }
    
    public async Task<ResultDto> Handle(UpdateSchoolModel request, CancellationToken cancellationToken)
    {
        var school = await _schoolRepository.GetSchoolById(request.Id);

        school.Name = request.Name;
        school.SchoolUrl = request.SchoolUrl;
        school.TimetableUrl = request.TimetableUrl;

        var result = await _schoolRepository.Update(school);
        
        return new ResultDto
        {
            Result = result
        };
    }
}