using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using Vulder.Protos.Search;
using Vulder.Search.Core.Models;
using Vulder.Search.Core.ProjectAggregate.School;
using Vulder.Search.Infrastructure.Data.Repository;

namespace Vulder.Search.Api.Services
{
    public class SearchService : Vulder.Protos.Search.Search.SearchBase
    {
        private readonly IMediator _mediator;

        public SearchService(ISchoolRepository repository, IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public override async Task<CreateResponse> Create(CreateRequest request, ServerCallContext context)
        {
            try
            {
                await _mediator.Send(new CreateSchoolModel
                {
                    Name = request.Name,
                    Url = request.Url,
                    RequesterEmail = request.RequesterEmail
                });

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

        public override async Task<FindResponse> Find(FindRequest request, ServerCallContext context)
        {
            var schools = await _mediator.Send(new SearchSchoolModel
            {
                Input = request.Input
            });
            
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

            return response;
        }
    }
}