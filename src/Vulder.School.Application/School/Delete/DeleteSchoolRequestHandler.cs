using MediatR;
using Vulder.School.Core.Models;
using Vulder.School.Core.ProjectAggregate.School.Dtos;
using Vulder.School.Infrastructure.Database.Interface;

namespace Vulder.School.Application.School.Delete;

public class DeleteSchoolRequestHandler : IRequestHandler<DeleteSchoolModel, ResultDto>
{
    private readonly ISchoolRepository _schoolRepository;
    
    public DeleteSchoolRequestHandler(ISchoolRepository schoolRepository)
    {
        _schoolRepository = schoolRepository;
    }
    
    public async Task<ResultDto> Handle(DeleteSchoolModel request, CancellationToken cancellationToken)
    {
        var result = await _schoolRepository.Delete(request.Id);

        return new ResultDto
        {
            Result = result
        };
    }
}