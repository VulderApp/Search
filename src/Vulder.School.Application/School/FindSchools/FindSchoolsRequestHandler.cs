using MediatR;
using Vulder.School.Core.Models;
using Vulder.School.Core.ProjectAggregate.School.Dtos;
using Vulder.School.Infrastructure.Database.Interface;

namespace Vulder.School.Application.School.FindSchools;

public class FindSchoolsRequestHandler : IRequestHandler<FindSchoolModel, List<Core.ProjectAggregate.School.School>>
{
    private readonly ISchoolRepository _schoolRepository;
    
    public FindSchoolsRequestHandler(ISchoolRepository schoolRepository)
    {
        _schoolRepository = schoolRepository;
    }
    
    public Task<List<Core.ProjectAggregate.School.School>> Handle(FindSchoolModel request, CancellationToken cancellationToken)
        => _schoolRepository.GetSchoolsByInput(request.Input!);
}