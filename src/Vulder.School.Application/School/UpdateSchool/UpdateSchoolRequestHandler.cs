using MediatR;
using Vulder.School.Core.Models;
using Vulder.School.Infrastructure.Database.Interface;

namespace Vulder.School.Application.School.UpdateSchool;

public class UpdateSchoolRequestHandler : IRequestHandler<UpdateSchoolModel, bool>
{
    private readonly ISchoolRepository _schoolRepository;
    
    public UpdateSchoolRequestHandler(ISchoolRepository schoolRepository)
    {
        _schoolRepository = schoolRepository;
    }
    
    public async Task<bool> Handle(UpdateSchoolModel request, CancellationToken cancellationToken)
    {
        var school = await _schoolRepository.GetSchoolById(request.Id);

        school.Name = request.Name;
        school.SchoolUrl = request.SchoolUrl;
        school.TimetableUrl = request.TimetableUrl;

        return await _schoolRepository.Update(school);
    }
}