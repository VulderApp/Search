using System;
using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using Vulder.Protos.Search;
using Vulder.Search.Core.Models;
using Vulder.Search.Infrastructure.Data.Repository;
using Vulder.Search.Infrastructure.Handler.School;

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
                    TimetableUrl = request.TimetableUrl,
                    SchoolUrl = request.SchoolUrl,
                    RequesterId = request.RequesterId,
                    RequesterEmail = request.RequesterEmail
                });

                return new CreateResponse
                {
                    IsCreated = true
                };
            }
            catch
            {
                return new CreateResponse
                {
                    IsCreated = false
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
                    Name = school.Name
                });
            }

            return response;
        }

        public override async Task<DeleteResponse> Delete(DeleteRequest request, ServerCallContext context)
        {
            var response = await _mediator.Send(new DeleteSchoolModel
            {
                SchoolId = Guid.Parse(request.SchoolId)
            });

            return new DeleteResponse
            {
                IsDeleted = response
            };
        }

        public override async Task<UpdateResponse> Update(UpdateRequest request, ServerCallContext context)
        {
            var response = await _mediator.Send(new UpdateSchoolModel
            {
                Id = Guid.Parse(request.SchoolId),
                SchoolName = request.Name,
                SchoolUrl = request.SchoolUrl,
                TimetableUrl = request.TimetableUrl,
                UserEmail = request.UserEmail,
                UserId = Guid.Parse(request.UserId)
            });
            
            return new UpdateResponse
            {
                IsUpdated = response
            };
        }
    }
}