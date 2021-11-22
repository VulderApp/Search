using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vulder.Search.Core.Models;

namespace Vulder.School.Api.Controllers.School;

[ApiController]
[Route("school/[controller]")]
public class AddSchoolController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    
    public AddSchoolController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddSchool([FromBody] AddSchoolModel addSchoolModel)
    {
        await _mediator.Send(
            _mapper.Map<Search.Core.ProjectAggregate.School.School>(addSchoolModel)
            );

        return Ok();
    }
}