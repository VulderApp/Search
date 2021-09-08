using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Vulder.Search.Core.Models;
using Vulder.Search.Infrastructure.Data.Repository;

namespace Vulder.Search.Infrastructure.Handler.School
{
    public class DeleteSchoolRequestHandler : IRequestHandler<DeleteSchoolModel, bool>
    {
        private readonly ISchoolRepository _repository;
        
        public DeleteSchoolRequestHandler(ISchoolRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<bool> Handle(DeleteSchoolModel request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.SchoolId);
            return true;
        }
    }
}