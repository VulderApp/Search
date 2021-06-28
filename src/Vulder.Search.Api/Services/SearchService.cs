using System.Threading.Tasks;
using Grpc.Core;
using Vulder.Protos.Search;
using Vulder.Search.Core.ProjectAggregate.School;
using Vulder.Search.Infrastructure.Data.Repository;

namespace Vulder.Search.Api.Services
{
    public class SearchService : Vulder.Protos.Search.Search.SearchBase
    {
        private readonly ISchoolRepository _repository;
        
        public SearchService(ISchoolRepository repository)
        {
            _repository = repository;
        }
        
        public override async Task<CreateResponse> Create(CreateRequest request, ServerCallContext context)
        {
            try
            {
                await _repository.Create(new School(request.Name, request.Url, request.RequesterEmail));

                return new CreateResponse
                {
                    Message = "Ok"
                };
            }
            catch
            {
                return new CreateResponse
                {
                    Message = "Error"
                };
            }
        }

        public override Task<FindResponse> Find(FindRequest request, ServerCallContext context)
        {
            var schools = _repository.Get(request.Input).Result;
            var response = new FindResponse();

            foreach (var school in schools)
            {
                response.Schools.Add(new FindResponse.Types.School
                {
                    Id = school.Id.ToString(),
                    Name = school.Name,
                    Url = school.Url
                });
            }

            return Task.FromResult(response);
        }
    }
}