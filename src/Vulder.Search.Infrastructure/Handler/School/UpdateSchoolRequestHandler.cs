using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Vulder.Search.Core.Models;
using Vulder.Search.Infrastructure.Data.Repository;

namespace Vulder.Search.Infrastructure.Handler.School
{
    public class UpdateSchoolRequestHandler : IRequestHandler<UpdateSchoolModel, bool>
    {
        private readonly ISchoolRepository _repository;
        
        public UpdateSchoolRequestHandler(ISchoolRepository repository)
        {
            _repository = repository;
        }


        public async Task<bool> Handle(UpdateSchoolModel request, CancellationToken cancellationToken)
        {
            var school = await _repository.Get(request.Id);

            school.Name = request.SchoolName;
            school.TimetableUrl = request.TimetableUrl;
            school.SchoolUrl = request.SchoolUrl;
            school.GuardianEmail = request.UserEmail;
            school.GuardianId = request.UserId;

            await _repository.Update(school);
            return true;
        }
    }
}