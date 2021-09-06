using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Vulder.Search.Core.Models;
using Vulder.Search.Infrastructure.Data.Repository;

namespace Vulder.Search.Infrastructure.Handler.School
{
    public class FindSchoolRequestHandler : IRequestHandler<SearchSchoolModel, List<Core.ProjectAggregate.School.School>>
    {
        private readonly ISchoolRepository _repository;
        
        public FindSchoolRequestHandler(ISchoolRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Core.ProjectAggregate.School.School>> Handle(SearchSchoolModel request, CancellationToken cancellationToken)
        {
            return _repository.Get(request.Input);
        }
    }
}