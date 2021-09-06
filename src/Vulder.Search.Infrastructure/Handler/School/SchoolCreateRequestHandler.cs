using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Vulder.Search.Core.Models;
using Vulder.Search.Infrastructure.Data.Repository;

namespace Vulder.Search.Infrastructure.Handler.School
{
    public class SchoolCreateRequestHandler : IRequestHandler<CreateSchoolModel, Unit>
    {
        private readonly ISchoolRepository _repository;

        public SchoolCreateRequestHandler(ISchoolRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateSchoolModel request, CancellationToken cancellationToken)
        {
            await _repository.Create(new Core.ProjectAggregate.School.School
            {
                Name = request.Name,
                Url = request.Url,
                GuardianEmail = request.RequesterEmail
            });
            
            return default;
        }
    }
}